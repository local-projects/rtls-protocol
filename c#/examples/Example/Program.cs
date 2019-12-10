using System;
using Google.Protobuf;
using RTLSProtocol;

namespace Example
{
    class Program
    {
        static private byte[] buildAndSerializeTrackableFrame()
        {
            // Create a new TrackableFrame, set its frame_id
            TrackableFrame frame = new TrackableFrame
            {
                FrameID = 1
            };

            // Create a new Trackable and set some values
            Trackable trackable1 = new Trackable
            {
                Name = "trackable1"
            };
            trackable1.Position = new Trackable.Types.Position
            {
                X = 1.0,
                Y = 2.0,
                Z = 3.0
            };
            // Add the Trackable to the TrackableFrame
            frame.Trackables.Add(trackable1);

            // Repeat with another Trackable
            Trackable trackable2 = new Trackable
            {
                Name = "trackable2"
            };
            trackable2.Position = new Trackable.Types.Position
            {
                X = 4.0,
                Y = 5.0,
                Z = 6.0
            };
            frame.Trackables.Add(trackable2);

            // You can use ToString() to inspect messages at any time
            Console.WriteLine("DEBUG STRING");
            Console.WriteLine("------------");
            Console.WriteLine(frame.ToString());
            Console.WriteLine();

            byte[] serialized = frame.ToByteArray();
            return serialized;
        }

        static private void parseAndPrintSerializedBytes(byte[] serialized) {
            // Create a new TrackableFrame and parse the data into it
            TrackableFrame frame = TrackableFrame.Parser.ParseFrom(serialized);

            // Console.WriteLine(frame.ToString());

            // Print individual fields
            Console.WriteLine("AFTER PARSING");
            Console.WriteLine("-------------");
            Console.WriteLine("Frame ID: {0}", frame.FrameID);
            Console.WriteLine();

            foreach (Trackable trackable in frame.Trackables)
            {
                Console.WriteLine("Name: {0}", trackable.Name);
                Console.WriteLine("x: {0}", trackable.Position.X);
                Console.WriteLine("y: {0}", trackable.Position.Y);
                Console.WriteLine("z: {0}", trackable.Position.Z);
                Console.WriteLine();
            }
        }

        static void Main(string[] args)
        {
            byte[] serialized = buildAndSerializeTrackableFrame();
            parseAndPrintSerializedBytes(serialized);
        }
    }
}
