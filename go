#!/usr/bin/env sh

if [ "$1" = "run" ]; then
  dotnet 10xDev/bin
  clear
  dotnet  10xDev/bin/10xDev.dll
fi

if [ "$1" = "test" ]; then
  dotnet test  10xDev.Tests
fi
