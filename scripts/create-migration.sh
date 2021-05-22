#!/bin/bash

MIGRATION_NAME="$1"

dotnet ef migrations add $MIGRATION_NAME --startup-project ./src/Aimrank.Agones.Cluster.Api --project ./src/Aimrank.Agones.Cluster.Infrastructure
