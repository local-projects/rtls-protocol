#include <iostream>
#include <string>

#include "../Trackable.pb.h"

using namespace std;
using namespace RTLSProtocol;

string buildAndSerializeTrackableFrame() {
    // Create a new TrackableFrame, set its frame_id
    TrackableFrame frame;
    frame.set_frame_id(1);

    // Add a new Trackable to the "trackables" array,
    // get a pointer to that new Trackable
    Trackable* trackable1 = frame.add_trackables();

    // Set some values
    trackable1->set_name("trackable1");
    Trackable::Position* position1 = trackable1->mutable_position();
    position1->set_x(1.0);
    position1->set_y(2.0);
    position1->set_z(3.0);

    // Repeat with another Trackable
    Trackable* trackable2 = frame.add_trackables();

    trackable2->set_name("trackable2");
    Trackable::Position* position2 = trackable2->mutable_position();
    position2->set_x(4.0);
    position2->set_y(5.0);
    position2->set_z(6.0);

    // You can use DebugString to inspect messages at any time
    cout << "DEBUG STRING" << endl;
    cout << "------------" << endl;
    cout << frame.DebugString() << endl << endl;

    // Serialize the data as a string of bytes
    string serialized = frame.SerializeAsString();

    return serialized;
}

void parseAndPrintSerializedString(string serialized) {
    // Create a new TrackableFrame that will contain the parsed data
    TrackableFrame frame;

    // Parse the string into the TrackableFrame object
    frame.ParseFromString(serialized);

    // cout << frame.DebugString() << endl << endl;
    
    // Print individual fields
    cout << "AFTER PARSING" << endl;
    cout << "-------------" << endl;
    cout << "Frame ID: " << frame.frame_id() << endl << endl;
    for (int i = 0; i < frame.trackables_size(); i++) {
        const Trackable& trackable = frame.trackables(i);
        cout << "Name: " << trackable.name() << endl;
        cout << "x: " << trackable.position().x() << endl;
        cout << "y: " << trackable.position().y() << endl;
        cout << "z: " << trackable.position().z() << endl;
        cout << endl;
    }
}

int main (int argc, char* argv[]) {
    string serialized = buildAndSerializeTrackableFrame();
    parseAndPrintSerializedString(serialized);
    return 0;
}