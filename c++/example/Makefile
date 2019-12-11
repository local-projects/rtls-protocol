.PHONY: all c++ clean

all: c++

clean:
	rm -f example_*

c++:
	pkg-config --cflags protobuf  # fails if protobuf is not installed
	c++ -std=c++11 example.cc ../Trackable.pb.cc -o  example_c++.out `pkg-config --cflags --libs protobuf`
