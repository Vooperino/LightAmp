﻿/*
 * Copyright(c) 2023 MoogleTroupe, isaki, GiR-Zippo
 * Licensed under the GPL v3 license. See https://github.com/GiR-Zippo/LightAmp/blob/main/LICENSE for full license information.
 */

using LiteDB;

namespace BardMusicPlayer.Coffer
{
    public sealed class LiteDBSchema
    {
        [BsonId]
        public int Id { get; set; } = Constants.SCHEMA_DOCUMENT_ID;
        public static byte Version => Constants.SCHEMA_VERSION;
    }
}
