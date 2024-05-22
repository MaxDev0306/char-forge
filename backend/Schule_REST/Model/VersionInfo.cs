namespace Schule_REST.Model
{
    public class VersionInfo
    {
        public string Name { get; set; }

        public string Version { get; set; }

        public VersionInfo(string name, int major, int minor, int build, int revision)
        {
            Name = name;
            Version = +major + "." + minor + "." + build + "." + revision;
        }
    }
}
