mergeInto(LibraryManager.library,
{
  LocalStorageWrite: function (keyPtr, valuePtr)
  {
    var key = UTF8ToString(keyPtr);
    var value = UTF8ToString(valuePtr);
    localStorage.setItem(key, value);
  },

  LocalStorageRead: function (keyPtr)
  {
    var key = UTF8ToString(keyPtr);
    var value = localStorage.getItem(key);
    if (value === null) // null = not found
    {
    	value = "";
    }
    var bufferSize = lengthBytesUTF8(value) + 1;
    var buffer = _malloc(bufferSize);
    stringToUTF8(value, buffer, bufferSize);
    return buffer;
  },

  LocalStorageHasKey: function (keyPtr)
  {
      var key = UTF8ToString(keyPtr);
      var value = localStorage.getItem(key);
      return (value === null) ? 0 : 1;
  },

  LocalStorageGetAllKeysWithPrefix: function(prefixPtr)
  {
      const prefix = UTF8ToString(prefixPtr);
      const result = [];

      for (let i = 0; i < localStorage.length; i++) {
        const key = localStorage.key(i);
        if (key.startsWith(prefix)) {
          result.push(key);
        }
      }

      const json = JSON.stringify(result);
      const size = lengthBytesUTF8(json) + 1;
      const buffer = _malloc(size);
      stringToUTF8(json, buffer, size);
      return buffer;
  },

  LocalStorageDelete: function (keyPtr)
  {
     var key = UTF8ToString(keyPtr);
     localStorage.removeItem(key);
  },

  LocalStorageDeleteByPrefix: function (prefixPtr)
  {
     var prefix = UTF8ToString(prefixPtr);
     var toDelete = [];
     for (var i = 0; i < localStorage.length; i++) {
       var key = localStorage.key(i);
       if (key.startsWith(prefix)) {
         toDelete.push(key);
       }
     }
     for (var j = 0; j < toDelete.length; j++) {
       localStorage.removeItem(toDelete[j]);
     }
  }
});
