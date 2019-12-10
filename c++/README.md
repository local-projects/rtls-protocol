# RTLS Protocol - C++

This folder contains the class definitions for `Trackable` and `TrackableFrame`
for use with C++ programs and applications.

I'd recommend becoming familiar with [Protobuf for C++](https://developers.google.com/protocol-buffers/docs/cpptutorial)
(there are some idiosyncracies) before diving in here.

If you specifically want to understand the generated code in `Trackable.pb.[h/cc]`, see [this](https://developers.google.com/protocol-buffers/docs/reference/cpp-generated).

If you want to optimize memory usage and improve performace, checkout [Arena Allocation](https://developers.google.com/protocol-buffers/docs/reference/arenas).

## Installation and usage

[Official C++ installation guide](https://github.com/protocolbuffers/protobuf/tree/master/src). Below is a simple usage guide which assumes that the C++ `protobuf` runtime libraries are already installed.

If you installed `protoc` via a package manager, it probably already installed the C++ Protobuf library too.
You can check with:

    pkg-config --cflags protobuf

which will fail if you don't have the library installed.

If you don't have the library, you can [build it from source](https://github.com/protocolbuffers/protobuf/tree/master/src).

In your source code, make sure to include `Trackable.pb.h`, and add `using namespace RTLS;`
right after.

When you compile, add `Trackable.pb.cc` as a source file, and include the Protobuf C++ library with:

    `pkg-config --cflags --libs protobuf`

See source code and Makefile in the examples folder for more details.

## Running the example

    cd examples/
    make
    ./example_c++
