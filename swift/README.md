# RTLS Protocol - Swift

`Trackable.pb.swift` contains the class definitions for `Trackable` and `TrackableFrame`
for use with Swift programs and applications.

Here is the [repo](https://github.com/apple/swift-protobuf) for Swift Protobuf,
which has some useful documentation.

You can find API documentation [here](https://github.com/apple/swift-protobuf/blob/master/Documentation/API.md).

If you specifically want to understand the generated code in `Trackable.pb.swift`, see [this](https://github.com/apple/swift-protobuf/blob/master/Documentation/INTERNALS.md).

## Installation and usage

[The Swift Protobuf repo](https://github.com/apple/swift-protobuf) has in-depth installation instructions for adding the SwiftProtobuf library to your project,
including CocoaPods and Carthage instructions.

The example uses the Swift Package Manager. Note that the version of the SwiftProtobuf library you use should match the version of the `protoc-gen-swift` plugin that was used to generate the `Trackable.pb.swift` file. You can check your version with `protoc-gen-swift --version`.

Once you've included the SwiftProtobuf library, add the Trackable.pb.swift file to your project and in your source code, just add:

    import Foundation
    import SwiftProtobuf

    // For readability
    typealias TrackableFrame = RTLSProtocol_TrackableFrame
    typealias Trackable = RTLSProtocol_Trackable


## Running the example

    cd example/
    swift run

Or, open the `example/` folder in Xcode 11 (or later) and Run.
