import os
from ament_index_python.packages import get_package_share_directory
from launch import LaunchDescription
from launch.actions import DeclareLaunchArgument, ExecuteProcess, IncludeLaunchDescription, RegisterEventHandler, SetEnvironmentVariable, TimerAction
from launch.conditions import IfCondition
from launch.substitutions import LaunchConfiguration
from launch.event_handlers import OnProcessExit
from launch.launch_description_sources import PythonLaunchDescriptionSource
from launch_ros.actions import Node
import xacro

import re

def generate_launch_description():
    pkg_share = get_package_share_directory('ros2_xyz_sim')
    gazebo_ros_share = get_package_share_directory('gazebo_ros')

    # Process Xacro using parse/process_doc and strip all XML comments to prevent rcl_arguments parser errors
    xacro_file = os.path.join(pkg_share, 'urdf', 'xyz_gantry.urdf.xacro')
    doc = xacro.parse(open(xacro_file))
    xacro.process_doc(doc)
    clean_xml = re.sub(r'<!--.*?-->', '', doc.toxml(), flags=re.DOTALL)
    robot_desc = {'robot_description': clean_xml}

    # World file
    world_path = os.path.join(pkg_share, 'worlds', 'industrial_workspace.world')

    # RViz Config
    rviz_config_file = os.path.join(pkg_share, 'config', 'rviz_config.rviz')

    # 1. Gazebo Server
    gzserver = IncludeLaunchDescription(
        PythonLaunchDescriptionSource(
            os.path.join(gazebo_ros_share, 'launch', 'gzserver.launch.py')
        ),
        launch_arguments={
            'world': world_path
        }.items()
    )

    # 2. Robot State Publisher
    robot_state_publisher_node = Node(
        package='robot_state_publisher',
        executable='robot_state_publisher',
        output='screen',
        parameters=[robot_desc]
    )

    # 3. Spawn Robot in Gazebo
    spawn_entity = Node(
        package='gazebo_ros',
        executable='spawn_entity.py',
        arguments=['-topic', 'robot_description', '-entity', 'xyz_gantry'],
        output='screen'
    )

    # 4. Spawners for ROS 2 Controllers
    spawner_joint_state_broadcaster = Node(
        package='controller_manager',
        executable='spawner',
        arguments=['joint_state_broadcaster', '--controller-manager-timeout', '30'],
        output='screen'
    )

    spawner_xyz_controller = Node(
        package='controller_manager',
        executable='spawner',
        arguments=['xyz_position_controller', '--controller-manager-timeout', '30'],
        output='screen'
    )

    # Declare use_rviz argument (mặc định tắt RViz2 để dồn toàn lực tài nguyên cho Gazebo mượt mà nhất)
    declare_use_rviz = DeclareLaunchArgument(
        'use_rviz',
        default_value='false',
        description='Whether to start RViz2'
    )

    # 5. RViz2 Node (chỉ chạy khi được bật)
    rviz_node = Node(
        package='rviz2',
        executable='rviz2',
        name='rviz2',
        arguments=['-d', rviz_config_file],
        output='screen',
        condition=IfCondition(LaunchConfiguration('use_rviz'))
    )

    # 6. Realtime IPC Shared Memory Bridge Node
    bridge_node = Node(
        package='ros2_xyz_sim',
        executable='sim_bridge_node',
        name='sim_bridge_node',
        output='screen'
    )

    # Setup GAZEBO_PLUGIN_PATH to locate libgazebo_toolpath_plugin.so
    ws_install_dir = os.path.abspath(os.path.join(pkg_share, '..', '..'))
    plugin_paths = [
        os.path.join(ws_install_dir, 'ros2_xyz_sim', 'lib'),
        os.path.join(ws_install_dir, 'ros2_xyz_sim', 'lib', 'ros2_xyz_sim'),
        os.path.join(ws_install_dir, 'lib'),
        os.environ.get('GAZEBO_PLUGIN_PATH', '')
    ]
    set_gazebo_plugin_path = SetEnvironmentVariable(
        name='GAZEBO_PLUGIN_PATH',
        value=':'.join([p for p in plugin_paths if p])
    )
    ld_paths = [
        os.path.join(ws_install_dir, 'ros2_xyz_sim', 'lib'),
        os.path.join(ws_install_dir, 'ros2_xyz_sim', 'lib', 'ros2_xyz_sim'),
        os.path.join(ws_install_dir, 'lib'),
        os.environ.get('LD_LIBRARY_PATH', '')
    ]
    set_ld_library_path = SetEnvironmentVariable(
        name='LD_LIBRARY_PATH',
        value=':'.join([p for p in ld_paths if p])
    )

    spawn_entity_timer = TimerAction(
        period=3.0,
        actions=[spawn_entity]
    )

    return LaunchDescription([
        set_gazebo_plugin_path,
        set_ld_library_path,
        declare_use_rviz,
        RegisterEventHandler(
            event_handler=OnProcessExit(
                target_action=spawn_entity,
                on_exit=[spawner_joint_state_broadcaster, spawner_xyz_controller],
            )
        ),
        gzserver,
        robot_state_publisher_node,
        spawn_entity_timer,
        rviz_node,
        bridge_node
    ])
