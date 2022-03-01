using System;

namespace behaviac
{
	// Token: 0x02002F26 RID: 12070
	public static class bt_Monster_AI_65Tuanben_Zhoufazhu_ACTION
	{
		// Token: 0x06014721 RID: 83745 RVA: 0x00626A4C File Offset: 0x00624E4C
		public static bool build_behavior_tree(BehaviorTree bt)
		{
			bt.SetClassNameString("BehaviorTree");
			bt.SetId(-1);
			bt.SetName("Monster_AI/65Tuanben/Zhoufazhu_ACTION");
			bt.IsFSM = false;
			Sequence sequence = new Sequence();
			sequence.SetClassNameString("Sequence");
			sequence.SetId(1);
			bt.AddChild(sequence);
			Condition_bt_Monster_AI_65Tuanben_Zhoufazhu_ACTION_node2 condition_bt_Monster_AI_65Tuanben_Zhoufazhu_ACTION_node = new Condition_bt_Monster_AI_65Tuanben_Zhoufazhu_ACTION_node2();
			condition_bt_Monster_AI_65Tuanben_Zhoufazhu_ACTION_node.SetClassNameString("Condition");
			condition_bt_Monster_AI_65Tuanben_Zhoufazhu_ACTION_node.SetId(2);
			sequence.AddChild(condition_bt_Monster_AI_65Tuanben_Zhoufazhu_ACTION_node);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_Monster_AI_65Tuanben_Zhoufazhu_ACTION_node.HasEvents());
			Condition_bt_Monster_AI_65Tuanben_Zhoufazhu_ACTION_node0 condition_bt_Monster_AI_65Tuanben_Zhoufazhu_ACTION_node2 = new Condition_bt_Monster_AI_65Tuanben_Zhoufazhu_ACTION_node0();
			condition_bt_Monster_AI_65Tuanben_Zhoufazhu_ACTION_node2.SetClassNameString("Condition");
			condition_bt_Monster_AI_65Tuanben_Zhoufazhu_ACTION_node2.SetId(0);
			sequence.AddChild(condition_bt_Monster_AI_65Tuanben_Zhoufazhu_ACTION_node2);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_Monster_AI_65Tuanben_Zhoufazhu_ACTION_node2.HasEvents());
			Action_bt_Monster_AI_65Tuanben_Zhoufazhu_ACTION_node3 action_bt_Monster_AI_65Tuanben_Zhoufazhu_ACTION_node = new Action_bt_Monster_AI_65Tuanben_Zhoufazhu_ACTION_node3();
			action_bt_Monster_AI_65Tuanben_Zhoufazhu_ACTION_node.SetClassNameString("Action");
			action_bt_Monster_AI_65Tuanben_Zhoufazhu_ACTION_node.SetId(3);
			sequence.AddChild(action_bt_Monster_AI_65Tuanben_Zhoufazhu_ACTION_node);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_Monster_AI_65Tuanben_Zhoufazhu_ACTION_node.HasEvents());
			bt.SetHasEvents(bt.HasEvents() | sequence.HasEvents());
			return true;
		}
	}
}
