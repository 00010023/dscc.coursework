{
  description = "Coursework from Distributed Cloud Computing";

  inputs.nixpkgs.url = "github:NixOS/nixpkgs/nixpkgs-unstable";
  
  outputs = { self, nixpkgs }: 

  let
    supportedSystems = [ "aarch64-darwin" ];
    forEachSupportedSystem = f: nixpkgs.lib.genAttrs supportedSystems (system: f {
      pkgs = import nixpkgs { inherit system; };
    });
  in
  {
    devShells = forEachSupportedSystem ({ pkgs }: {
      default = pkgs.mkShell {
        packages = with pkgs; [
          # Too old
          #dotnet-sdk_6

          # Perfect!
          dotnet-sdk_7

          # Too beta
          #dotnet-sdk_8
          
          omnisharp-roslyn
          mono
          msbuild
          nil
        ];

        shellHook = ''
          export GIT_AUTHOR_EMAIL='00010023@wiut.uz'
          export GIT_AUTHOR_NAME='00010023'
        '';
      };
    });
  };
}
