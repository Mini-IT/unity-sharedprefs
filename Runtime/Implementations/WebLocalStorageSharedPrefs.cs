#if UNITY_WEBGL && !UNITY_EDITOR

using System.Globalization;
using System.Runtime.CompilerServices;

namespace MiniIT.Storage.Unity
{
	internal sealed class WebLocalStorageSharedPrefs : ISharedPrefs
	{
		private const string PREFIX = "miniit.prefs-";

		public void DeleteAll()
		{
			WebLocalStorage.DeleteByPrefix(PREFIX);
		}

		public void DeleteKey(string key)
		{
			key = GetKey(key);
			WebLocalStorage.DeleteByPrefix(key);
		}

		public bool GetBool(string key, bool defaultValue = false)
		{
			key = GetKey(key);
			string value = WebLocalStorage.Read(key);
			if (int.TryParse(value, out int val))
			{
				return (val != 0);
			}
			return defaultValue;
		}

		public float GetFloat(string key, float defaultValue = 0f)
		{
			key = GetKey(key);
			string value = WebLocalStorage.Read(key);
			if (float.TryParse(value, out float val))
			{
				return val;
			}
			return defaultValue;
		}

		public int GetInt(string key, int defaultValue = 0)
		{
			key = GetKey(key);
			string value = WebLocalStorage.Read(key);
			if (int.TryParse(value, out int val))
			{
				return val;
			}
			return defaultValue;
		}

		public string GetString(string key, string defaultValue = null)
		{
			key = GetKey(key);
			string value = WebLocalStorage.Read(key);
			if (string.IsNullOrEmpty(value))
			{
				return defaultValue;
			}
			return value;
		}

		public bool HasKey(string key)
		{
			key = GetKey(key);
			return WebLocalStorage.HasKey(key);
		}

		public void Save()
		{
			// Do nothing
		}

		public void SetBool(string key, bool value)
		{
			SetInt(key, value ? 1 : 0);
		}

		public void SetFloat(string key, float value)
		{
			key = GetKey(key);
			WebLocalStorage.Write(key, value.ToString(CultureInfo.InvariantCulture));
		}

		public void SetInt(string key, int value)
		{
			key = GetKey(key);
			WebLocalStorage.Write(key, value.ToString(CultureInfo.InvariantCulture));
		}

		public void SetString(string key, string value)
		{
			key = GetKey(key);
			WebLocalStorage.Write(key, value);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private string GetKey(string key)
		{
			return string.Concat(PREFIX, key);
		}
	}
}

#endif
