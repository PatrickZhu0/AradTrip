using System;
using GameClient;
using Network;
using Protocol;
using UnityEngine;

// Token: 0x0200456C RID: 17772
public class ClientApplication
{
	// Token: 0x17002069 RID: 8297
	// (get) Token: 0x06018CA9 RID: 101545 RVA: 0x007BEDDF File Offset: 0x007BD1DF
	// (set) Token: 0x06018CAA RID: 101546 RVA: 0x007BEDE6 File Offset: 0x007BD1E6
	public static uint serverStartTime
	{
		get
		{
			return ClientApplication.mServerStartTime;
		}
		set
		{
			ClientApplication.mServerStartTime = value;
		}
	}

	// Token: 0x1700206A RID: 8298
	// (get) Token: 0x06018CAB RID: 101547 RVA: 0x007BEDEE File Offset: 0x007BD1EE
	// (set) Token: 0x06018CAC RID: 101548 RVA: 0x007BEDF5 File Offset: 0x007BD1F5
	public static uint veteranReturn
	{
		get
		{
			return ClientApplication.mVeteranReturn;
		}
		set
		{
			ClientApplication.mVeteranReturn = value;
		}
	}

	// Token: 0x06018CAD RID: 101549 RVA: 0x007BEDFD File Offset: 0x007BD1FD
	public static AsyncOperation LoadLevelAsync(int index)
	{
		if (ClientApplication.ops != null)
		{
			ClientApplication.ops.allowSceneActivation = true;
		}
		ClientApplication.ops = Application.LoadLevelAsync(index);
		return ClientApplication.ops;
	}

	// Token: 0x06018CAE RID: 101550 RVA: 0x007BEE24 File Offset: 0x007BD224
	public static void DisconnectGateServerAtLogin()
	{
		Singleton<ClientReconnectManager>.instance.canRelogin = false;
		NetManager.Instance().Disconnect(ServerType.GATE_SERVER);
		ClientApplication.adminServer.ip = string.Empty;
		ClientApplication.adminServer.port = 0;
		ClientApplication.gateServer.ip = string.Empty;
		ClientApplication.gateServer.port = 0;
	}

	// Token: 0x06018CAF RID: 101551 RVA: 0x007BEE7B File Offset: 0x007BD27B
	public static bool HasRoles()
	{
		return ClientApplication.playerinfo != null && ClientApplication.playerinfo.roleinfo != null && ClientApplication.playerinfo.roleinfo.Length > 0;
	}

	// Token: 0x04011DCD RID: 73165
	public static bool m_bReg = false;

	// Token: 0x04011DCE RID: 73166
	public static PlayerInfo playerinfo = new PlayerInfo();

	// Token: 0x04011DCF RID: 73167
	public static RacePlayerInfo[] racePlayerInfo = new RacePlayerInfo[2];

	// Token: 0x04011DD0 RID: 73168
	public static AdminServerAddr adminServer = new AdminServerAddr();

	// Token: 0x04011DD1 RID: 73169
	public static SockAddr gateServer = new SockAddr();

	// Token: 0x04011DD2 RID: 73170
	public static SockAddr relayServer = new SockAddr();

	// Token: 0x04011DD3 RID: 73171
	public static string replayServer = string.Empty;

	// Token: 0x04011DD4 RID: 73172
	public static string channelRankListServer = string.Empty;

	// Token: 0x04011DD5 RID: 73173
	public static string operateAdsServer = string.Empty;

	// Token: 0x04011DD6 RID: 73174
	public static bool isEncryptProtocol = true;

	// Token: 0x04011DD7 RID: 73175
	public static string commentServerAddr = string.Empty;

	// Token: 0x04011DD8 RID: 73176
	public static string redPackRankServerPath = string.Empty;

	// Token: 0x04011DD9 RID: 73177
	public static string reportPlayerUrl = string.Empty;

	// Token: 0x04011DDA RID: 73178
	public static string convertAccountInfoUrl = string.Empty;

	// Token: 0x04011DDB RID: 73179
	public static string questionnaireUrl = string.Empty;

	// Token: 0x04011DDC RID: 73180
	private static uint mServerStartTime = 0U;

	// Token: 0x04011DDD RID: 73181
	private static uint mVeteranReturn = 0U;

	// Token: 0x04011DDE RID: 73182
	public static AsyncOperation ops;
}
