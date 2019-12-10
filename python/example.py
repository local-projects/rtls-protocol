from __future__ import print_function
from Trackable_pb2 import TrackableFrame, Trackable
import sys


def buildAndSerializeTrackableFrame():
    # Create a new TrackableFrame, set its frame_ID
    frame = TrackableFrame()
    frame.frame_ID = 1

    # Add a new Trackable to the "trackables" array
    trackable1 = frame.trackables.add()
    # Set some values
    trackable1.name = "trackable1"
    trackable1.position.x = 1.0
    trackable1.position.y = 2.0
    trackable1.position.z = 3.0

    # Repeat with another Trackable
    trackable2 = frame.trackables.add()
    trackable2.name = "trackable2"
    trackable2.position.x = 4.0
    trackable2.position.y = 5.0
    trackable2.position.z = 6.0

    # You can print messages directly or get a debug string with str(MESSAGE)
    print("DEBUG STRING")
    print("------------")
    print(frame)
    print("")

    serialized = frame.SerializeToString()
    return serialized


def parseAndPrintSerializedString(serialized):
    # Create a new TrackableFrame and parse the data into it
    frame = TrackableFrame()
    frame.ParseFromString(serialized)

    # print(frame)

    # Print individual fields
    print("AFTER PARSING")
    print("-------------")
    print("Frame ID:", frame.frame_ID)
    print("")

    for trackable in frame.trackables:
        print("Name:", trackable.name)
        print("x:", trackable.position.x)
        print("y:", trackable.position.y)
        print("z:", trackable.position.z)
        print("")


serialized = buildAndSerializeTrackableFrame()
parseAndPrintSerializedString(serialized)
