using Sharpmake;
using System.IO;
using System.Diagnostics;

[Generate]
public class Entt : ThirdPartyProject
{
  public Entt() : base()
  {
    // The name of the project in Visual Studio. The default is the name of
    // the class, but you usually want to override that.
    Name = GenerateName("Entt");
    GenerateTargets();

    // The directory that contains the source code we want to build is the
    // same as this one. This string essentially means "the directory of
    // the script you're reading right now."
    string ThisFileFolder = Path.GetDirectoryName(Utils.CurrentFile());
    SourceRootPath = ThisFileFolder;
  }

  protected override void SetupIncludePaths(RexConfiguration conf, RexTarget target)
  {
    base.SetupIncludePaths(conf, target);

    conf.IncludePaths.Add(SourceRootPath);
    conf.IncludePaths.Add(Path.Combine(SourceRootPath, "src"));
  }

  protected override void SetupConfigSettings(RexConfiguration conf, RexTarget target)
  {
    base.SetupConfigSettings(conf, target);

    conf.Options.Remove(Options.Vc.General.TreatWarningsAsErrors.Enable);
  }

  protected override void SetupPostBuildEvents(RexConfiguration conf, RexTarget target)
  {
    // Purposely don't use base post build events
    // Nothing to implement otherwise
  }
}