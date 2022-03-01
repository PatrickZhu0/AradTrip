using System;

namespace behaviac
{
	// Token: 0x02002B2D RID: 11053
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Level_Tuanben_TuanBen_Xinzang_node2 : Action
	{
		// Token: 0x06013F6B RID: 81771 RVA: 0x005FE68F File Offset: 0x005FCA8F
		public Action_bt_Level_Tuanben_TuanBen_Xinzang_node2()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = "Sound/Dungeon/boss_Tuanben_tongyong.ogg";
		}

		// Token: 0x06013F6C RID: 81772 RVA: 0x005FE6A9 File Offset: 0x005FCAA9
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((LevelAgent)pAgent).Action_PlayBgm(this.method_p0);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D9A3 RID: 55715
		private string method_p0;
	}
}
