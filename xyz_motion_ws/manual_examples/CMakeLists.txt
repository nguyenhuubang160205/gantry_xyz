cmake_minimum_required(VERSION 3.16)
project(manual_examples CXX)

set(CMAKE_CXX_STANDARD 17)
set(CMAKE_CXX_STANDARD_REQUIRED ON)
set(CMAKE_EXPORT_COMPILE_COMMANDS ON)

add_definitions(-D__stdcall=)
add_compile_options(-include cstddef)

include_directories(
    ${CMAKE_CURRENT_SOURCE_DIR}/../libaxm_core/include
)

link_directories(
    ${CMAKE_CURRENT_SOURCE_DIR}/../lib
)

set(CMAKE_BUILD_RPATH "${CMAKE_CURRENT_SOURCE_DIR}/../lib")
set(CMAKE_INSTALL_RPATH "$ORIGIN/../lib:${CMAKE_CURRENT_SOURCE_DIR}/../lib")
set(CMAKE_INSTALL_RPATH_USE_LINK_PATH TRUE)

# Tự động tìm và build toàn bộ 14 bài thực hành Ex01..Ex14 trong thư mục manual_examples
file(GLOB CPP_FILES "${CMAKE_CURRENT_SOURCE_DIR}/*.cpp")
list(FILTER CPP_FILES EXCLUDE REGEX "tempCodeRunnerFile\\.cpp$")

foreach(CPP_FILE ${CPP_FILES})
    get_filename_component(APP ${CPP_FILE} NAME_WE)
    add_executable(${APP} ${CPP_FILE})
    target_link_libraries(${APP}
        ${CMAKE_CURRENT_SOURCE_DIR}/../lib/libaxm_sim.so
        pthread
        rt
    )
    set_target_properties(${APP} PROPERTIES
        BUILD_RPATH "${CMAKE_CURRENT_SOURCE_DIR}/../lib"
        INSTALL_RPATH "$ORIGIN/../lib:${CMAKE_CURRENT_SOURCE_DIR}/../lib"
    )
endforeach()
