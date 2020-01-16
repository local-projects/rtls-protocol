var RTLSProtocol = require("./Trackable_pb");
var TrackableFrame = RTLSProtocol.TrackableFrame;
var Trackable = RTLSProtocol.Trackable;

function buildAndSerializeTrackableFrame() {
    // Create a new TrackableFrame, set its frameId
    var frame = new TrackableFrame();
    frame.setFrameId(1);

    // Add a new Trackable to the "trackables" array,
    var trackable1 = frame.addTrackables();
    // Set some values
    trackable1.setName("trackable1");
    var position1 = new Trackable.Position();
    position1.setX(1.0);
    position1.setY(2.0);
    position1.setZ(3.0);
    trackable1.setPosition(position1);

    // Repeat with another Trackable
    var trackable2 = frame.addTrackables();
    trackable2.setName("trackable2");
    var position2 = new Trackable.Position();
    position2.setX(4.0);
    position2.setY(5.0);
    position2.setZ(6.0);
    trackable2.setPosition(position2);

    // You can use toObject() to inspect messages at any time
    console.log("DEBUG LOG");
    console.log("---------");
    console.log(frame.toObject());
    console.log();

    // Serialize the data to binary
    var serialized = frame.serializeBinary();
    return serialized;
}

function parseAndPrintSerializedData(serialized) {
    // Create a new TrackableFrame and parse the data into it
    var frame = TrackableFrame.deserializeBinary(serialized);

    // console.log(frame.toObject())

    // Print individual fields
    console.log("AFTER PARSING");
    console.log("-------------");
    console.log("Frame ID:", frame.getFrameId());
    frame.getTrackablesList().forEach(t => {
        console.log("Name:", t.getName());
        console.log("x:", t.getPosition().getX());
        console.log("y:", t.getPosition().getY());
        console.log("z:", t.getPosition().getZ());
        console.log("");
    });
}

var serialized = buildAndSerializeTrackableFrame();
parseAndPrintSerializedData(serialized);
