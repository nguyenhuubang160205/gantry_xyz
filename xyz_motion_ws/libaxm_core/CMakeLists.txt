cmake_minimum_required(VERSION 3.16)
project(libaxm_core CXX)

set(CMAKE_CXX_STANDARD 17)
set(CMAKE_CXX_STANDARD_REQUIRED ON)
set(CMAKE_POSITION_INDEPENDENT_CODE ON)

add_definitions(-D__stdcall=)
add_compile_options(-include cstddef)

include_directories(
    ${CMAKE_CURRENT_SOURCE_DIR}/include
)

set(SOURCES
    src/axl_system.cpp
    src/axm_motion_ptp.cpp
    src/axm_motion_interp.cpp
    src/axm_motion_conti.cpp
    src/axm_homing.cpp
    src/axm_signals.cpp
    src/MotionCore.cpp
)

add_library(axm_sim SHARED ${SOURCES})

target_link_libraries(axm_sim
    pthread
    rt
)

# Output library name: libaxm_sim.so
set_target_properties(axm_sim PROPERTIES
    OUTPUT_NAME "axm_sim"
    PREFIX "lib"
    LIBRARY_OUTPUT_DIRECTORY ${CMAKE_CURRENT_BINARY_DIR}
)

# Also copy to workspace lib directory
add_custom_command(TARGET axm_sim POST_BUILD
    COMMAND ${CMAKE_COMMAND} -E make_directory ${CMAKE_CURRENT_SOURCE_DIR}/../lib
    COMMAND ${CMAKE_COMMAND} -E copy $<TARGET_FILE:axm_sim> ${CMAKE_CURRENT_SOURCE_DIR}/../lib/
)
