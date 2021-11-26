using System;
using System.Collections.Generic;
using System.Linq;
using dnlib.DotNet;

namespace Inferno_Obfuscation
{
	// Token: 0x0200004C RID: 76
	public class RenamerPhase
	{
		// Token: 0x06000173 RID: 371 RVA: 0x00020294 File Offset: 0x0001E494
		public static void Execute(ModuleDefMD module)
		{
			bool isObfuscationActive = RenamerPhase.IsObfuscationActive;
			if (isObfuscationActive)
			{
				string namespaceNewName = RenamerPhase.GenerateString(RenamerPhase.RenameMode.Normal);
				foreach (TypeDef type in module.Types)
				{
					bool canRenameType;
					bool flag = RenamerPhase.TypeRename.TryGetValue(type, out canRenameType);
					if (flag)
					{
						bool flag2 = canRenameType && type.IsSerializable;
						if (flag2)
						{
							RenamerPhase.InternalRename(type);
						}
					}
					else
					{
						RenamerPhase.InternalRename(type);
					}
					foreach (MethodDef method in type.Methods)
					{
						bool canRenameMethod;
						bool flag3 = RenamerPhase.MethodRename.TryGetValue(method, out canRenameMethod);
						if (flag3)
						{
							bool flag4 = canRenameMethod && !method.IsConstructor && !method.IsSpecialName;
							if (flag4)
							{
								RenamerPhase.InternalRename(method);
							}
						}
						else
						{
							RenamerPhase.InternalRename(method);
						}
					}
					RenamerPhase.MethodNewName.Clear();
					foreach (FieldDef field in type.Fields)
					{
						bool canRenameField;
						bool flag5 = RenamerPhase.FieldRename.TryGetValue(field, out canRenameField);
						if (flag5)
						{
							bool flag6 = canRenameField;
							if (flag6)
							{
								RenamerPhase.InternalRename(field);
							}
						}
						else
						{
							RenamerPhase.InternalRename(field);
						}
					}
					RenamerPhase.FieldNewName.Clear();
				}
			}
			else
			{
				foreach (KeyValuePair<TypeDef, bool> typeItem2 in from typeItem in RenamerPhase.TypeRename
				where typeItem.Value
				select typeItem)
				{
					RenamerPhase.InternalRename(typeItem2.Key);
				}
				foreach (KeyValuePair<MethodDef, bool> methodItem2 in from methodItem in RenamerPhase.MethodRename
				where methodItem.Value
				select methodItem)
				{
					RenamerPhase.InternalRename(methodItem2.Key);
				}
				foreach (KeyValuePair<FieldDef, bool> fieldItem2 in from fieldItem in RenamerPhase.FieldRename
				where fieldItem.Value
				select fieldItem)
				{
					RenamerPhase.InternalRename(fieldItem2.Key);
				}
			}
		}

		// Token: 0x06000174 RID: 372 RVA: 0x000205DC File Offset: 0x0001E7DC
		private static void InternalRename(TypeDef type)
		{
			string randString = RenamerPhase.GenerateString(RenamerPhase.RenameMode.Normal);
			while (RenamerPhase.TypeNewName.Contains(randString))
			{
				randString = RenamerPhase.GenerateString(RenamerPhase.RenameMode.Normal);
			}
			RenamerPhase.TypeNewName.Add(randString);
			type.Name = randString;
		}

		// Token: 0x06000175 RID: 373 RVA: 0x00020624 File Offset: 0x0001E824
		private static void InternalRename(MethodDef method)
		{
			string randString = RenamerPhase.GenerateString(RenamerPhase.RenameMode.Normal);
			while (RenamerPhase.MethodNewName.Contains(randString))
			{
				randString = RenamerPhase.GenerateString(RenamerPhase.RenameMode.Normal);
			}
			RenamerPhase.MethodNewName.Add(randString);
			method.Name = randString;
		}

		// Token: 0x06000176 RID: 374 RVA: 0x0002066C File Offset: 0x0001E86C
		private static void InternalRename(FieldDef field)
		{
			string randString = RenamerPhase.GenerateString(RenamerPhase.RenameMode.Normal);
			while (RenamerPhase.FieldNewName.Contains(randString))
			{
				randString = RenamerPhase.GenerateString(RenamerPhase.RenameMode.Normal);
			}
			RenamerPhase.FieldNewName.Add(randString);
			field.Name = randString;
		}

		// Token: 0x06000177 RID: 375 RVA: 0x000206B4 File Offset: 0x0001E8B4
		private static string RandomString(int length, string chars)
		{
			return new string((from s in Enumerable.Repeat<string>(chars, length)
			select s[RenamerPhase.Random.Next(s.Length)]).ToArray<char>());
		}

		// Token: 0x06000178 RID: 376 RVA: 0x000206FC File Offset: 0x0001E8FC
		public static string GetRandomName()
		{
			return RenamerPhase.NormalNameStrings[RenamerPhase.Random.Next(RenamerPhase.NormalNameStrings.Length)];
		}

		// Token: 0x06000179 RID: 377 RVA: 0x00020728 File Offset: 0x0001E928
		public static string GenerateString(RenamerPhase.RenameMode mode)
		{
			string result;
			if (mode != RenamerPhase.RenameMode.Ascii)
			{
				if (mode != RenamerPhase.RenameMode.Normal)
				{
					throw new ArgumentOutOfRangeException("mode", mode, null);
				}
				result = RenamerPhase.GetRandomName();
			}
			else
			{
				result = RenamerPhase.RandomString(RenamerPhase.Random.Next(1, 7), RenamerPhase.Ascii);
			}
			return result;
		}

		// Token: 0x0400009E RID: 158
		private static readonly Dictionary<TypeDef, bool> TypeRename = new Dictionary<TypeDef, bool>();

		// Token: 0x0400009F RID: 159
		private static readonly List<string> TypeNewName = new List<string>();

		// Token: 0x040000A0 RID: 160
		private static readonly Dictionary<MethodDef, bool> MethodRename = new Dictionary<MethodDef, bool>();

		// Token: 0x040000A1 RID: 161
		private static readonly List<string> MethodNewName = new List<string>();

		// Token: 0x040000A2 RID: 162
		private static readonly Dictionary<FieldDef, bool> FieldRename = new Dictionary<FieldDef, bool>();

		// Token: 0x040000A3 RID: 163
		private static readonly List<string> FieldNewName = new List<string>();

		// Token: 0x040000A4 RID: 164
		public static bool IsObfuscationActive = true;

		// Token: 0x040000A5 RID: 165
		public static Random Random = new Random();

		// Token: 0x040000A6 RID: 166
		public static string[] NormalNameStrings = new string[]
		{
			"HasPermission",
			"HasPermissions",
			"GetPermissions",
			"GetOpenWindows",
			"EnumWindows",
			"GetWindowText",
			"GetWindowTextLength",
			"IsWindowVisible",
			"GetShellWindow",
			"Awake",
			"FixedUpdate",
			"add_OnRockedInitialized",
			"remove_OnRockedInitialized",
			"Awake",
			"Initialize",
			"Translate",
			"Reload",
			"<Initialize>b__13_0",
			"Initialize",
			"FixedUpdate",
			"Start",
			"checkTimerRestart",
			"QueueOnMainThread",
			"QueueOnMainThread",
			"RunAsync",
			"RunAction",
			"Awake",
			"FixedUpdate",
			"IsUri",
			"GetTypes",
			"GetTypesFromParentClass",
			"GetTypesFromParentClass",
			"GetTypesFromInterface",
			"GetTypesFromInterface",
			"get_Timeout",
			"set_Timeout",
			"GetWebRequest",
			"get_SteamID64",
			"set_SteamID64",
			"get_SteamID",
			"set_SteamID",
			"get_OnlineState",
			"set_OnlineState",
			"get_StateMessage",
			"set_StateMessage",
			"get_PrivacyState",
			"set_PrivacyState",
			"get_VisibilityState",
			"set_VisibilityState",
			"get_AvatarIcon",
			"set_AvatarIcon",
			"get_AvatarMedium",
			"set_AvatarMedium",
			"get_AvatarFull",
			"set_AvatarFull",
			"get_IsVacBanned",
			"set_IsVacBanned",
			"get_TradeBanState",
			"set_TradeBanState",
			"get_IsLimitedAccount",
			"set_IsLimitedAccount",
			"get_CustomURL",
			"set_CustomURL",
			"get_MemberSince",
			"set_MemberSince",
			"get_HoursPlayedLastTwoWeeks",
			"set_HoursPlayedLastTwoWeeks",
			"get_Headline",
			"set_Headline",
			"get_Location",
			"set_Location",
			"get_RealName",
			"set_RealName",
			"get_Summary",
			"set_Summary",
			"get_MostPlayedGames",
			"set_MostPlayedGames",
			"get_Groups",
			"set_Groups",
			"Reload",
			"ParseString",
			"ParseDateTime",
			"ParseDouble",
			"ParseUInt16",
			"ParseUInt32",
			"ParseUInt64",
			"ParseBool",
			"ParseUri",
			"IsValidCSteamID",
			"LoadDefaults",
			"LoadDefaults",
			"get_Clients",
			"Awake",
			"handleConnection",
			"FixedUpdate",
			"Broadcast",
			"OnDestroy",
			"Read",
			"Send",
			"<Awake>b__8_0",
			"get_InstanceID",
			"set_InstanceID",
			"get_ConnectedTime",
			"set_ConnectedTime",
			"Send",
			"Read",
			"Close",
			"get_Address",
			"get_Instance",
			"set_Instance",
			"Save",
			"Load",
			"Unload",
			"Load",
			"Save",
			"Load",
			"get_Configuration",
			"LoadPlugin",
			"<.ctor>b__3_0",
			"<LoadPlugin>b__4_0",
			"add_OnPluginUnloading",
			"remove_OnPluginUnloading",
			"add_OnPluginLoading",
			"remove_OnPluginLoading",
			"get_Translations",
			"get_State",
			"get_Assembly",
			"set_Assembly",
			"get_Directory",
			"set_Directory",
			"get_Name",
			"set_Name",
			"get_DefaultTranslations",
			"IsDependencyLoaded",
			"ExecuteDependencyCode",
			"Translate",
			"ReloadPlugin",
			"LoadPlugin",
			"UnloadPlugin",
			"OnEnable",
			"OnDisable",
			"Load",
			"Unload",
			"TryAddComponent",
			"TryRemoveComponent",
			"add_OnPluginsLoaded",
			"remove_OnPluginsLoaded",
			"get_Plugins",
			"GetPlugins",
			"GetPlugin",
			"GetPlugin",
			"Awake",
			"Start",
			"GetMainTypeFromAssembly",
			"loadPlugins",
			"unloadPlugins",
			"Reload",
			"GetAssembliesFromDirectory",
			"LoadAssembliesFromDirectory",
			"<Awake>b__12_0",
			"GetGroupsByIds",
			"GetParentGroups",
			"HasPermission",
			"GetGroup",
			"RemovePlayerFromGroup",
			"AddPlayerToGroup",
			"DeleteGroup",
			"SaveGroup",
			"AddGroup",
			"GetGroups",
			"GetPermissions",
			"GetPermissions",
			"<GetGroups>b__11_3",
			"Start",
			"FixedUpdate",
			"Reload",
			"HasPermission",
			"GetGroups",
			"GetPermissions",
			"GetPermissions",
			"AddPlayerToGroup",
			"RemovePlayerFromGroup",
			"GetGroup",
			"SaveGroup",
			"AddGroup",
			"DeleteGroup",
			"DeleteGroup",
			"<FixedUpdate>b__4_0",
			"Enqueue",
			"_Logger_DoWork",
			"processLog",
			"Log",
			"Log",
			"var_dump",
			"LogWarning",
			"LogError",
			"LogError",
			"Log",
			"LogException",
			"ProcessInternalLog",
			"logRCON",
			"writeToConsole",
			"ProcessLog",
			"ExternalLog",
			"Invoke",
			"_invoke",
			"TryInvoke",
			"get_Aliases",
			"get_AllowedCaller",
			"get_Help",
			"get_Name",
			"get_Permissions",
			"get_Syntax",
			"Execute",
			"get_Aliases",
			"get_AllowedCaller",
			"get_Help",
			"get_Name",
			"get_Permissions",
			"get_Syntax",
			"Execute",
			"get_Aliases",
			"get_AllowedCaller",
			"get_Help",
			"get_Name",
			"get_Permissions",
			"get_Syntax",
			"Execute",
			"get_Name",
			"set_Name",
			"get_Name",
			"set_Name",
			"get_Name",
			"get_Help",
			"get_Syntax",
			"get_AllowedCaller",
			"get_Commands",
			"set_Commands",
			"add_OnExecuteCommand",
			"remove_OnExecuteCommand",
			"Reload",
			"Awake",
			"checkCommandMappings",
			"checkDuplicateCommandMappings",
			"Plugins_OnPluginsLoaded",
			"GetCommand",
			"GetCommand",
			"getCommandIdentity",
			"getCommandType",
			"Register",
			"Register",
			"Register",
			"DeregisterFromAssembly",
			"GetCooldown",
			"SetCooldown",
			"Execute",
			"RegisterFromAssembly"
		};

		// Token: 0x040000A7 RID: 167
		public static string Ascii = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmn痹瘕番畐畵地狱迷惑阿約拉Inferno Obfuscator阿約拉地狱迷惑畵opqrstuvwxyz0123456789";

		// Token: 0x02000093 RID: 147
		public enum RenameMode
		{
			// Token: 0x0400015A RID: 346
			Ascii,
			// Token: 0x0400015B RID: 347
			Normal
		}
	}
}
