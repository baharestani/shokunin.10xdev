#!/usr/bin/env sh

if [ $# = 0 ]; then
  dotnet build 10xDev -o bin
  dotnet 10xDev/bin/10xDev.dll
fi

if [ "$1" = "test" ]; then
  dotnet test 10xDev.Tests
fi
