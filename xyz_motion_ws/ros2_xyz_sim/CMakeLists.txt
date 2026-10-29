set(CMAKE_POLICY_VERSION_MINIMUM 3.5)
cmake_minimum_required(VERSION 3.16)
project(ros2_xyz_sim)

# Default to C++17
if(NOT CMAKE_CXX_STANDARD)
  set(CMAKE_CXX_STANDARD 17)
endif()

find_package(ament_cmake REQUIRED)
find_package(rclcpp REQUIRED)
find_package(std_msgs REQUIRED)
find_package(sensor_msgs REQUIRED)
find_package(geometry_msgs REQUIRED)
find_package(gazebo_msgs REQUIRED)

find_package(PkgConfig REQUIRED)
pkg_check_modules(GAZEBO REQUIRED gazebo)
pkg_check_modules(OGRE REQUIRED OGRE OGRE-Paging OGRE-Terrain OGRE-RTShaderSystem)
find_package(Qt5 REQUIRED COMPONENTS Widgets Core Gui)

set(CMAKE_AUTOMOC ON)

include_directories(
  include
  ${CMAKE_CURRENT_SOURCE_DIR}/../libaxm_core/include
  ${GAZEBO_INCLUDE_DIRS}
  ${OGRE_INCLUDE_DIRS}
)

# ROS 2 IPC Bridge Node
add_executable(sim_bridge_node src/sim_bridge_node.cpp)
ament_target_dependencies(sim_bridge_node
  rclcpp
  std_msgs
  sensor_msgs
  geometry_msgs
  gazebo_msgs
)
target_link_libraries(sim_bridge_node
  pthread
  rt
)

# Gazebo GUI Toolpath Tracer Plugin
add_library(gazebo_toolpath_plugin SHARED
  src/gazebo_toolpath_plugin.cpp
  include/gazebo_toolpath_plugin.hpp
)
target_include_directories(gazebo_toolpath_plugin PUBLIC
  include
  ${CMAKE_CURRENT_SOURCE_DIR}/../libaxm_core/include
  ${GAZEBO_INCLUDE_DIRS}
  ${OGRE_INCLUDE_DIRS}
  ${Qt5Widgets_INCLUDE_DIRS}
)
target_link_libraries(gazebo_toolpath_plugin
  ${GAZEBO_LIBRARIES}
  Qt5::Widgets
  Qt5::Core
  Qt5::Gui
  pthread
  rt
)

install(TARGETS
  sim_bridge_node
  gazebo_toolpath_plugin
  DESTINATION lib/${PROJECT_NAME}
)

install(TARGETS
  gazebo_toolpath_plugin
  DESTINATION lib
)

install(DIRECTORY
  config
  launch
  urdf
  worlds
  materials
  DESTINATION share/${PROJECT_NAME}
)

ament_package()
