#!/bin/bash

docker build -t ghcr.io/aimrank/aimrank-agones-cluster:$1 -f Dockerfile .
