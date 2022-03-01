using System;

namespace behaviac
{
	// Token: 0x0200356D RID: 13677
	public static class bt_Monster_AI_Huodong_Ani3thMG_YXG_Tiaotiaole
	{
		// Token: 0x06015312 RID: 86802 RVA: 0x0066318C File Offset: 0x0066158C
		public static bool build_behavior_tree(BehaviorTree bt)
		{
			bt.SetClassNameString("BehaviorTree");
			bt.SetId(-1);
			bt.SetName("Monster_AI/Huodong/Ani3thMG_YXG_Tiaotiaole");
			bt.IsFSM = false;
			Sequence sequence = new Sequence();
			sequence.SetClassNameString("Sequence");
			sequence.SetId(1);
			bt.AddChild(sequence);
			Action_bt_Monster_AI_Huodong_Ani3thMG_YXG_Tiaotiaole_node2 action_bt_Monster_AI_Huodong_Ani3thMG_YXG_Tiaotiaole_node = new Action_bt_Monster_AI_Huodong_Ani3thMG_YXG_Tiaotiaole_node2();
			action_bt_Monster_AI_Huodong_Ani3thMG_YXG_Tiaotiaole_node.SetClassNameString("Action");
			action_bt_Monster_AI_Huodong_Ani3thMG_YXG_Tiaotiaole_node.SetId(2);
			sequence.AddChild(action_bt_Monster_AI_Huodong_Ani3thMG_YXG_Tiaotiaole_node);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_Monster_AI_Huodong_Ani3thMG_YXG_Tiaotiaole_node.HasEvents());
			Action_bt_Monster_AI_Huodong_Ani3thMG_YXG_Tiaotiaole_node0 action_bt_Monster_AI_Huodong_Ani3thMG_YXG_Tiaotiaole_node2 = new Action_bt_Monster_AI_Huodong_Ani3thMG_YXG_Tiaotiaole_node0();
			action_bt_Monster_AI_Huodong_Ani3thMG_YXG_Tiaotiaole_node2.SetClassNameString("Action");
			action_bt_Monster_AI_Huodong_Ani3thMG_YXG_Tiaotiaole_node2.SetId(0);
			sequence.AddChild(action_bt_Monster_AI_Huodong_Ani3thMG_YXG_Tiaotiaole_node2);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_Monster_AI_Huodong_Ani3thMG_YXG_Tiaotiaole_node2.HasEvents());
			bt.SetHasEvents(bt.HasEvents() | sequence.HasEvents());
			return true;
		}
	}
}
