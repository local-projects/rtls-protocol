import Foundation
import SwiftProtobuf

// For readability
typealias TrackableFrame = RTLSProtocol_TrackableFrame
typealias Trackable = RTLSProtocol_Trackable


func buildAndSerializeTrackableFrame() -> Data {
    // Create a new TrackableFrame, set its frameID
    var frame = TrackableFrame()
    frame.frameID = 1
	
	// Create a new Trackable and set some values
	var trackable1 = Trackable()
	trackable1.name = "trackable1"
	trackable1.position.x = 1.0
	trackable1.position.y = 2.0
	trackable1.position.z = 3.0
	
	// Add the Trackable to the TrackableFrame
	frame.trackables.append(trackable1)
	
	// Repeat with another Trackable
	var trackable2 = Trackable()
	trackable2.name = "trackable2"
	trackable2.position.x = 4.0
	trackable2.position.y = 5.0
	trackable2.position.z = 6.0
	frame.trackables.append(trackable2)
	
	// You can print messages directly to see the debug string
	// or you can get the string with MESSAGE.debugDescription
    print("DEBUG STRING")
	print("------------")
	print(frame)
	print("")
	
	// Serialize the data to binary
	let serialized = try! frame.serializedData()
	return serialized
}

func parseAndPrintSerializedData(serialized: Data) {
	// Create a new TrackableFrame and parse the data into it
	let frame = try! TrackableFrame(serializedData: serialized)
	
	// print(frame)
	
	// Print individual fields
	print("AFTER PARSING")
	print("-------------")
	print("Frame ID:", frame.frameID)
	print("")
	
	for trackable in frame.trackables {
		print("Name:", trackable.name)
        print("x:", trackable.position.x)
        print("y:", trackable.position.y)
        print("z:", trackable.position.z)
        print("")
	}
}

let serialized = buildAndSerializeTrackableFrame()
parseAndPrintSerializedData(serialized: serialized)
