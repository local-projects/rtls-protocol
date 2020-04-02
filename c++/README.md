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

1. Install [vcpkg](https://github.com/microsoft/vcpkg). 
    1. Open Git Bash. Navigate to the "C:/" directory and create a "dev" directory if it doesn't exist. Navigate into the "dev" directory".
        ```bash
        cd C:/
        mkdir -p dev
        cd dev
    2. Clone the vcpkg repo and navigate into it.
        ```bash
        git clone https://github.com/Microsoft/vcpkg.git
        cd vcpkg
        ```
    3. Open a Powershell window in admin mode and navigate to the vcpkg directory. Then, run the following commands. This will create a vcpkg binary and install it system-wide. The last command will set a system-wide variable `VCPKG` to the location of vcpkg.
        ```bash
        cd C:\dev\vcpkg
        .\bootstrap-vcpkg.bat
        .\vcpkg integrate install
        setx VCPKG "C:\dev\vcpkg" /M
        ```
2. Install protobuf.
    1. In a Powershell window, navigate to the vcpkg directory (if not already there) and install the protobuf packages.
        ```bash
        cd C:\dev\vcpkg
        .\vcpkg install protobuf protobuf:x64-windows
        ```
    2. If you would like to automatically link any vcpkg packages to c++ VS projects, then make vcpkg accessible system-wide with the following command.
        ```bash
        .\vcpkg integrate install
        ```
    Sometimes, system-wide installation produces strange behaviors in Visual Studio projects. In those cases, it may be wise to forgoe this and manually include any headers, libs and dlls. Disabling system wide integration consists of the following command:
        ```bash
        .\vcpkg integrate remove
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
