using System;

namespace behaviac
{
	// Token: 0x02002AE7 RID: 10983
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Level_Tuanben_TuanBen_Chap_2_Zui_Level_node1 : Action
	{
		// Token: 0x06013EE5 RID: 81637 RVA: 0x005FB72F File Offset: 0x005F9B2F
		public Action_bt_Level_Tuanben_TuanBen_Chap_2_Zui_Level_node1()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = "Sound/Dungeon/boss_Tuanben_tongyong.ogg";
		}

		// Token: 0x06013EE6 RID: 81638 RVA: 0x005FB749 File Offset: 0x005F9B49
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((LevelAgent)pAgent).Action_PlayBgm(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D94B RID: 55627
		private string method_p0;
	}
}
