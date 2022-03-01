using System;

namespace GameClient
{
	// Token: 0x0200450F RID: 17679
	public class FrameCommandFactory
	{
		// Token: 0x0601897E RID: 100734 RVA: 0x007AE4C8 File Offset: 0x007AC8C8
		public static IFrameCommand CreateCommand(uint Type)
		{
			switch (Type)
			{
			case 0U:
				return new GameStartFrame();
			case 1U:
				return new MoveFrameCommand();
			case 2U:
				return new StopFrameCommand();
			case 3U:
				return new SkillFrameCommand();
			case 4U:
				return new LeaveFrameCommand();
			case 5U:
				return new RebornFrameCommand();
			case 7U:
				return new ReconnectFrameCommand();
			case 8U:
				return new UseItemFrameCommand();
			case 9U:
				return new LevelChangeCommand();
			case 10U:
				return new AutoFightCommand();
			case 11U:
				return new DoublePressConfigCommand();
			case 12U:
				return new PlayerQuitCommand();
			case 13U:
				return new RaceEndCommand();
			case 14U:
				return new NetQualityCommand();
			case 15U:
				return new RacePuaseFrame();
			case 16U:
				return new SceneChangeArea();
			case 17U:
				return new StopSkillCommand();
			case 18U:
				return new DoAttackCommand();
			case 19U:
				return new MatchRoundVote();
			case 20U:
				return new PassDoorCommand();
			case 21U:
				return new ChangeWeaponCommand();
			case 22U:
				return new DoSyncSightCommand();
			case 23U:
				return new BossPhaseChange();
			case 24U:
				return new DungeonDestory();
			case 25U:
				return new TeamCopyRaceEnd();
			case 26U:
				return new DungeonProcess();
			case 27U:
				return new AddRebornCntCommand();
			case 28U:
				return new CancelRebornCommand();
			}
			return null;
		}
	}
}
