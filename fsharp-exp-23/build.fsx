#if FAKE
#r "paket:
nuget Fake.DotNet.Cli
nuget Fake.IO.FileSystem
nuget Fake.Core.Target prerelease"
#endif

#load ".fake/build.fsx/intellisense.fsx"

open Fake.Core
open Fake.DotNet
open Fake.IO
open Fake.IO.FileSystemOperators
open Fake.IO.Globbing.Operators
open Fake.Core.TargetOperators

Target.initEnvironment ()

// Alternative: Read from global json
let install = lazy DotNet.install DotNet.Versions.FromGlobalJson

// Define general properties across various commands (with arguments)
let inline withWorkDir wd =
    DotNet.Options.lift install.Value
    >> DotNet.Options.withWorkingDirectory wd

// Set general properties without arguments
let inline dotnetSimple arg = DotNet.Options.lift install.Value arg

// Use defined properties on "DotNet.Exec"
//  "myproject.fsproj"

Target.create "Clean" (fun _ -> !! "**/bin" ++ "**/obj" |> Shell.cleanDirs)

let exec arg = DotNet.exec dotnetSimple "build" arg |> ignore

// Target.create "Build" (fun _ -> !! "*.*proj" |> Seq.iter (DotNet.build id))
// Target.create "Build" (fun _ -> !! "*.*proj" |> Seq.iter (exec))
Target.create "Build" (fun _ -> DotNet.exec dotnetSimple "build" "fsharp-exp-23.fsproj" |> ignore)
// Target.create "Build" (fun _ -> !! "*.*proj" |> Seq.iter (DotNet.exec dotnetSimple "build"))

Target.create "All" ignore

"Clean" ==> "Build" ==> "All"

Target.runOrDefault "All"
