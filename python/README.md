# RTLS Protocol - Python

`Trackable_pb2.py` contains the class definitions for `Trackable` and `TrackableFrame`
for use with Python programs and applications.

I'd recommend becoming familiar with [Protobuf for Python](https://developers.google.com/protocol-buffers/docs/pythontutorial) before diving in here.

If you specifically want to understand the generated code in `Trackable_pb.py`, see [this](https://developers.google.com/protocol-buffers/docs/reference/python-generated).

## Installation and usage

[Official Python installation guide](https://github.com/protocolbuffers/protobuf/tree/master/python)

You can also install with `pip`:

    pip install protobuf

This installs the Protobuf Python runtime libraries.

Then, in your source code, just add:

    from Trackable_pb2 import TrackableFrame, Trackable

## Running the example

    python example.py
