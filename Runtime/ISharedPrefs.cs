
namespace MiniIT.Storage
{
	public interface ISharedPrefs
	{
		bool HasKey(string key);
		void DeleteKey(string key);
		void DeleteAll();
		void Save();

		bool   GetBool(string key, bool defaultValue = default);
		float  GetFloat(string key, float defaultValue = default);
		int    GetInt(string key, int defaultValue = default);
		string GetString(string key, string defaultValue = default);

		void SetBool(string key, bool value);
		void SetFloat(string key, float value);
		void SetInt(string key, int value);
		void SetString(string key, string value);
	}
}
