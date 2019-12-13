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

First, get [vcpkg](https://github.com/microsoft/vcpkg).

Then:

    vcpkg install protobuf protobuf:x64-windows
    vcpkg integrate install

### Usage

In your source code, make sure to include `Trackable.pb.h`, and add `using namespace RTLS;`
right after.

When you compile, add `Trackable.pb.cc` as a source file, and include the Protobuf C++ library with:

    `pkg-config --cflags --libs protobuf`

See source code and Makefile in the examples folder for more details.

## Running the example

    cd example/
    make
    ./example_c++
