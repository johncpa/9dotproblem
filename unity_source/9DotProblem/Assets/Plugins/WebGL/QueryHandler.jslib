var QueryHandler = {
    GetURL: function(){
        var url = window.top.location.href;
        console.log("Plugin: url found: " + url);

        var returnStr = url;
        var bufferSize = lengthBytesUTF8(returnStr) + 1;
        var buffer = _malloc(bufferSize);
        stringToUTF8(returnStr, buffer, bufferSize);
        return buffer;
    }
};
mergeInto(LibraryManager.library, QueryHandler);
