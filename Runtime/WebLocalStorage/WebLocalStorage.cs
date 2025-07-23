using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

namespace MiniIT.Storage
{
	public static class WebLocalStorage
	{
		[DllImport("__Internal")] private static extern void LocalStorageWrite(string key, string value);
		[DllImport("__Internal")] private static extern string LocalStorageRead(string key);
		[DllImport("__Internal")] private static extern string LocalStorageGetAllKeysWithPrefix(string prefix);
		[DllImport("__Internal")] private static extern void LocalStorageDelete(string key);
		[DllImport("__Internal")] private static extern void LocalStorageDeleteByPrefix(string prefix);
		[DllImport("__Internal")] private static extern int LocalStorageHasKey(string prefix);

		public static void Write(string key, string value)
		{
			LocalStorageWrite(key, value);
		}

		public static string Read(string key)
		{
			return LocalStorageRead(key);
		}

		public static string[] GetKeysByPrefix(string prefix)
		{
			string json = LocalStorageGetAllKeysWithPrefix(prefix);
			return JsonUtility.FromJson<Wrapper>(json).keys;
		}

		public static void Delete(string key)
		{
			LocalStorageDelete(key);
		}

		public static void DeleteByPrefix(string prefix)
		{
			LocalStorageDeleteByPrefix(prefix);
		}

		public static bool HasKey(string key)
		{
			return LocalStorageHasKey(key) == 1;
		}

		[Serializable]
		private class Wrapper
		{
			public string[] keys;
		}
	}
}
