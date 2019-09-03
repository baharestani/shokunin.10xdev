#!/usr/bin/env sh

if [ $# = 0 ]; then
  dotnet run -p 10xDev
fi

if [ "$1" = "test" ]; then
  dotnet test 10xDev.Tests
fi
