# Export the env
export NIXPKGS_ALLOW_UNSUPPORTED_SYSTEM=1

# Start the nix development environment
nix develop --impure -c $SHELL