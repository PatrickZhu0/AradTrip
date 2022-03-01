using System;

namespace behaviac
{
	// Token: 0x02002B32 RID: 11058
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Level_Tuanben_TuanBen_Zhuijizhan_node2 : Action
	{
		// Token: 0x06013F74 RID: 81780 RVA: 0x005FE8A6 File Offset: 0x005FCCA6
		public Action_bt_Level_Tuanben_TuanBen_Zhuijizhan_node2()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = "Sound/Dungeon/boss_Tuanben_zhuiji.ogg";
		}

		// Token: 0x06013F75 RID: 81781 RVA: 0x005FE8C0 File Offset: 0x005FCCC0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((LevelAgent)pAgent).Action_PlayBgm(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D9A5 RID: 55717
		private string method_p0;
	}
}
