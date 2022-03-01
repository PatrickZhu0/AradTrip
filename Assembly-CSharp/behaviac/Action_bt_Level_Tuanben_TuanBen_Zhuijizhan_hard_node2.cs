using System;

namespace behaviac
{
	// Token: 0x02002B37 RID: 11063
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Level_Tuanben_TuanBen_Zhuijizhan_hard_node2 : Action
	{
		// Token: 0x06013F7D RID: 81789 RVA: 0x005FEABA File Offset: 0x005FCEBA
		public Action_bt_Level_Tuanben_TuanBen_Zhuijizhan_hard_node2()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = "Sound/Dungeon/boss_Tuanben_zhuiji.ogg";
		}

		// Token: 0x06013F7E RID: 81790 RVA: 0x005FEAD4 File Offset: 0x005FCED4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((LevelAgent)pAgent).Action_PlayBgm(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D9A7 RID: 55719
		private string method_p0;
	}
}
