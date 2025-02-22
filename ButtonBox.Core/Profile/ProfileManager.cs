using Newtonsoft.Json;
using System.IO;
using System.Net;
namespace ButtonBoxApp.Brain.Profile;

public partial class ProfileManagerService
{
    //todo if no json exists, make a new one

    public ProfileManagerService()
    {
        _profileList = LoadLayoutProfileList();
    }


#region fields

    private List<LayoutProfile>? _profileList;
    private readonly string _profilesFilePath = "\\ButtonBoxApp.Brain\\Json\\Profiles.json";

#endregion

#region Properties

    public List<LayoutProfile>? ProfileList{ get; private set; }

#endregion

#region Public Methods

    public List<LayoutProfile> LoadLayoutProfileList()
    {
        if (File.Exists(_profilesFilePath))
        {
            var json = File.ReadAllText(_profilesFilePath);
            return JsonConvert.DeserializeObject<List<LayoutProfile>>(json) ?? new List<LayoutProfile>();
        }
        return new List<LayoutProfile>();
    }

    public void SaveLayoutProfileList()
    {
        var json = JsonConvert.SerializeObject(ProfileList, Formatting.Indented);
        File.WriteAllText(_profilesFilePath, json);
    }

    public void AddLayoutProfile(LayoutProfile LayoutProfile)
    {
        ProfileList.Add(LayoutProfile);
        SaveLayoutProfileList();
    }

    public void RemoveLayoutProfile(LayoutProfile LayoutProfile)
    {
        ProfileList.Remove(LayoutProfile);
        SaveLayoutProfileList();
    }
  
    public LayoutProfile? InitializeCurrentLayoutProfile()
    {

        if (ProfileList != null && ProfileList.Count < 1) return new LayoutProfile("No Profile Selected...");

        else return ProfileList?.FirstOrDefault();

    }

#endregion

}
