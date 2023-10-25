#!/bin/bash

# Ensure the new nigger's author and email are provided
if [ "$#" -ne 3 ]; then
    echo "Nigga, you forgot to pass some shit"
    echo "Usage: $0 NIGGER_NAME NIGGER_EMAIL NIGGER_KEY"
    exit 1
fi

NIGGER_NAME="$1"
NIGGER_EMAIL="$2"
NIGGER_KEY="$3"

# Function to change the nigger author and email
nigga_filter_branch() {
    git filter-branch --env-filter '
    export GIT_AUTHOR_NAME="$1"
    export GIT_AUTHOR_EMAIL="$2"
    export GIT_COMMITTER_NAME="$1"
    export GIT_COMMITTER_EMAIL="$2"
    ' HEAD
}

# Run the function
nigga_filter_branch "$NIGGER_NAME" "$NIGGER_EMAIL"

# Now, push the niggas
GIT_SSH_COMMAND="ssh -i $NIGGER_KEY" git push origin master
unset GIT_SSH_COMMAND