# RTLS Protocol - JavaScirpt

`Trackable_pb.js` contains the class definitions for `Trackable` and `TrackableFrame`
for use with JavaScript applications (browser and node.js).

Protobuf for JavaScript isn't currently well-documented, but you can go [here](https://developers.google.com/protocol-buffers/docs/reference/python-generated) to understand the generated code in `Trackable_pb.js` a little better. Also check out the [example](./example) in this repo.

## Installation and usage

[Official JavaScript installation guide](https://github.com/protocolbuffers/protobuf/tree/master/js)

Basically, just install with `npm`:

    npm install google-protobuf

This installs the Protobuf JavaScript runtime libraries for your project. Add `-g` to install globally.

Then, in your source code, just add:

    var RTLSProtocol = require("./Trackable_pb");
    var TrackableFrame = RTLSProtocol.TrackableFrame;
    var Trackable = RTLSProtocol.Trackable;

## Running the example

    cd example/
    npm install
    npm start
