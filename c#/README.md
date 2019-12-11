# RTLS Protocol - C\

`Trackable.cs` contains the class definitions for `Trackable` and `TrackableFrame`
for use with C# programs and applications.

I'd recommend becoming familiar with [Protobuf for C#](https://developers.google.com/protocol-buffers/docs/csharptutorial) before diving in here.

If you specifically want to understand the generated code in `Trackable.cs`, see [this](https://developers.google.com/protocol-buffers/docs/reference/csharp-generated).

## Installation and usage

[Official C# installation guide](https://github.com/protocolbuffers/protobuf/tree/master/csharp). The instructions below are a summary.

Inside your project directory, run:

    dotnet add package Google.Protobuf

to install the Protobuf NuGet package.

In your source code, just add:

    using RTLSProtocol;
    using Google.Protobuf // for some useful utilities

## Running the example

    cd Example/
    dotnet build Example.csproj
    mono /PATH/TO/EXECUTABLE   # might be a .dll
