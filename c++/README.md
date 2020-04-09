# RTLS Protocol - C++

This folder contains the class definitions for `Trackable` and `TrackableFrame`
for use with C++ programs and applications.

I'd recommend becoming familiar with [Protobuf for C++](https://developers.google.com/protocol-buffers/docs/cpptutorial)
(there are some idiosyncracies) before diving in here.

If you specifically want to understand the generated code in `Trackable.pb.[h/cc]`, see [this](https://developers.google.com/protocol-buffers/docs/reference/cpp-generated).

If you want to optimize memory usage and improve performace, checkout [Arena Allocation](https://developers.google.com/protocol-buffers/docs/reference/arenas).

## Installation and usage

[Official C++ installation guide](https://github.com/protocolbuffers/protobuf/tree/master/src). Quick start guide is below:

### Mac installation

    brew install protobuf

### Windows(x64) installation

Complete these steps in a Powershell window in admin mode.
1. Install [vcpkg](https://github.com/microsoft/vcpkg). Run the following commands. They will clone the vcpkg repo into the dev directory, then build vcpkg. The last command will set a system-wide variable `VCPKG` to the location of vcpkg.
    ```bash
    git clone https://github.com/Microsoft/vcpkg.git C:\dev\vcpkg
    C:\dev\vcpkg\bootstrap-vcpkg.bat
    setx VCPKG "C:\dev\vcpkg" /M
    ```
2. Install protobuf. In a Powershell window, navigate to the vcpkg directory (if not already there) and install the protobuf packages.
    ```bash
    C:\dev\vcpkg\vcpkg install protobuf protobuf:x64-windows
    ```
3. Link Packages. 
    If you would like Visual Studio to automatically link packages to your project, then use the following command in Powershell to make accessible system-wide with the following command. (Note: Sometimes, system-wide installation produces strange behaviors in Visual Studio projects.)
    ```bash
    C:\dev\vcpkg\vcpkg integrate install
    ```
    Otherwiese, if you would like to manually include the packages, disable systemwide integration with the following command.
    ```bash
    C:\dev\vcpkg\vcpkg integrate remove
    ```

### Usage

In your source code, make sure to include `Trackable.pb.h`, and add `using namespace RTLS;`
right after.

When you compile, add `Trackable.pb.cc` as a source file, and include the Protobuf C++ library with:

    `pkg-config --cflags --libs protobuf`

See source code and Makefile in the examples folder for more details.

## Running the example

On Mac:
    cd example/
    make
    ./example_c++.out

On Windows, compile with CMake
