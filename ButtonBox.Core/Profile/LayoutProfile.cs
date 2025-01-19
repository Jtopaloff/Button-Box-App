namespace ButtonBoxV3.Brain.Profile
{
    public class LayoutProfile
    {

        public LayoutProfile(string profileName)
        {
            ProfileName = profileName;
        }

        private string? _profileName;
        private string? _gameName;

        public string? ProfileName { get => _profileName; set => _profileName = value; }
        public string? GameName { get => _gameName; set => _gameName = value; }






    }
}
