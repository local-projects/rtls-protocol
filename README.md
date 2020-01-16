# Real-Time Location System (RTLS) Protocol

This is a [Google Protobuf](https://developers.google.com/protocol-buffers) implementation of a custom protocol
(loosely based on [RTTrP](https://rttrp.github.io/RTTrP-Wiki/index.html)) for sending and receiving real-time
tracking data obtained from hardware such as HTC Vive, Oculus or other custom location-tracking hardware devices.

## Overview

The protocol is defined in `Trackable.proto` and consists of two main "message" types
that can be serialized or deserialized via Protobuf: **Trackable** and **TrackableFrame**.

Headers have already been generated for C++, C#, Python and Swift. You can find additional
language-specifc information (including simple examples) in the respective folder.

Below is a description of the fields in each message. Note that **all fields are optional**.

## `Trackable`

Contains the data and metadata for a single trackable device, for a single frame

| **Field**                                  | **Description**                                                                                                          |
| ------------------------------------------ | ------------------------------------------------------------------------------------------------------------------------ |
| int32 `id`                                 | an ID number that is unique to a device; could be unknown (`-1`)                                                         |
| bytes `cuid`                               | a unique 128-bit ID that is used for persistent identification across frames, but does not identify the actual device    |
| string `name`                              | an alphanumeric label for the device, such as its serial number                                                          |
| uint64 `frame_ID`                          | the sequential frame number. Can be used to determine order of messages when using UDP                                   |
| uint64 `timestamp`                         | Unix timestamp in milliseconds. Can be used to manually calculate velocity, acceleration, jerk etc. from positional data |
| bytes `context`                            | variable length field for any metadata for which a field does not already exist                                          |
| repeated Trackable `children`              | a recursively defined array of `Trackable` messages, e.g. to group controllers under a headset                           |
| Position `position`                        | the position of the Trackable, defined with `(double) x,y,z` coordinates                                                 |
| Orientation `orientation`                  | the orientation of the Trackable, defined as a quaternion with `(double) x,y,z,w` coordinates                            |
| Velocity `velocity`                        | the positional velocity of the Trackable defined with `(float) x,y,z` coordinates                                        |
| Acceleration `acceleration`                | the positional acceleration of the Trackable defined with `(float) x,y,z` coordinates                                    |
| AngularVelocity `angular_velocity`         | the angular velocity of the Trackable defined around `(float) x,y,z` axes                                                |
| AngularAcceleration `angular_acceleration` | the angular accerlation of the Trackable defined around `(float) x,y,z` axes                                             |

## `TrackableFrame`

Contains the data and metadata for an array of trackable devices, for a single frame

| **Field**                       | **Description**                                                                                                                 |
| ------------------------------- | ------------------------------------------------------------------------------------------------------------------------------- |
| repeated Trackable `trackables` | an array of `Trackable` messages as defined above                                                                               |
| uint64 `frame_ID`               | Same as for a `Trackable`. If all Trackables in a frame have the same `frame_ID`, it's more efficient to specify it once, here  |
| uint64 `timestamp`              | Same as for a `Trackable`. If all Trackables in a frame have the same `timestamp`, it's more efficient to specify it once, here |
| bytes `context`                 | variable length field for any metadata for which a field does not already exist                                                 |

## Compiling for C++, C#, Python (, Java, Objective-C, PHP, Ruby)

First, make sure you have the `protoc` compiler installed. You can download it [here](https://developers.google.com/protocol-buffers/docs/downloads.html).

Now, make sure you are in the root of the repo, and then run:

    protoc --LANGUAGE_OPTION=$DST_DIR Trackable.proto

For example, for C++ you would run:

    protoc --cpp_out=c++ Trackable.proto

This will generate files (in the respective directory) that define `Trackable` and `TrackableFrame` classes.

You can find the language option flags for other languages with a quick

    protoc -h

## Compiling for JavaScript
The process is mostly the same as above. The only difference is that you need to add an option to tell the compiler whether you want Closure imports or CommonJS imports (the normal `require()` way). You also need to add a `binary` option to make sure the serialize/deserialize methods get generated.

For CommonJS imports:

    protoc --js_out=import_style=commonjs,binary:js Trackable.proto

For more info, see [here](https://github.com/protocolbuffers/protobuf/tree/master/js).

## Compiling for Swift

First, install the Swift plugin for the Protobuf compiler with

    brew install swift-protobuf    # for Mac. For other platforms, build from source: https://github.com/apple/swift-protobuf

Then run:

    protoc --swift_out=swift Trackable.proto

## Compiling for other languages

See if the language you want is listed [here](https://github.com/protocolbuffers/protobuf/blob/master/docs/third_party.md).

## Usage

See the example in each language's directory to get a sense of how to use the protocol. Essentially, you
package up all your information into a `Trackable` object or `TrackableFrame` object, serialize it, and send it.
On the receiving end, you deserialize to get back the object, and from there you can inspect it's fields.

There is a lot of documentation on how to use Protobuf in general, [here](https://developers.google.com/protocol-buffers/docs/overview),
and some good language specific tutorials, [here](https://developers.google.com/protocol-buffers/docs/tutorials).
