using System;

namespace behaviac
{
	// Token: 0x020030D5 RID: 12501
	public static class bt_Monster_AI_Chapter10_Tiaotiaowa_skill_tiaotiaowa_veryhard
	{
		// Token: 0x06014A62 RID: 84578 RVA: 0x00637D14 File Offset: 0x00636114
		public static bool build_behavior_tree(BehaviorTree bt)
		{
			bt.SetClassNameString("BehaviorTree");
			bt.SetId(-1);
			bt.SetName("Monster_AI/Chapter10/Tiaotiaowa/skill_tiaotiaowa_veryhard");
			bt.IsFSM = false;
			Sequence sequence = new Sequence();
			sequence.SetClassNameString("Sequence");
			sequence.SetId(0);
			bt.AddChild(sequence);
			Condition_bt_Monster_AI_Chapter10_Tiaotiaowa_skill_tiaotiaowa_veryhard_node2 condition_bt_Monster_AI_Chapter10_Tiaotiaowa_skill_tiaotiaowa_veryhard_node = new Condition_bt_Monster_AI_Chapter10_Tiaotiaowa_skill_tiaotiaowa_veryhard_node2();
			condition_bt_Monster_AI_Chapter10_Tiaotiaowa_skill_tiaotiaowa_veryhard_node.SetClassNameString("Condition");
			condition_bt_Monster_AI_Chapter10_Tiaotiaowa_skill_tiaotiaowa_veryhard_node.SetId(2);
			sequence.AddChild(condition_bt_Monster_AI_Chapter10_Tiaotiaowa_skill_tiaotiaowa_veryhard_node);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_Monster_AI_Chapter10_Tiaotiaowa_skill_tiaotiaowa_veryhard_node.HasEvents());
			Condition_bt_Monster_AI_Chapter10_Tiaotiaowa_skill_tiaotiaowa_veryhard_node1 condition_bt_Monster_AI_Chapter10_Tiaotiaowa_skill_tiaotiaowa_veryhard_node2 = new Condition_bt_Monster_AI_Chapter10_Tiaotiaowa_skill_tiaotiaowa_veryhard_node1();
			condition_bt_Monster_AI_Chapter10_Tiaotiaowa_skill_tiaotiaowa_veryhard_node2.SetClassNameString("Condition");
			condition_bt_Monster_AI_Chapter10_Tiaotiaowa_skill_tiaotiaowa_veryhard_node2.SetId(1);
			sequence.AddChild(condition_bt_Monster_AI_Chapter10_Tiaotiaowa_skill_tiaotiaowa_veryhard_node2);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_Monster_AI_Chapter10_Tiaotiaowa_skill_tiaotiaowa_veryhard_node2.HasEvents());
			Action_bt_Monster_AI_Chapter10_Tiaotiaowa_skill_tiaotiaowa_veryhard_node3 action_bt_Monster_AI_Chapter10_Tiaotiaowa_skill_tiaotiaowa_veryhard_node = new Action_bt_Monster_AI_Chapter10_Tiaotiaowa_skill_tiaotiaowa_veryhard_node3();
			action_bt_Monster_AI_Chapter10_Tiaotiaowa_skill_tiaotiaowa_veryhard_node.SetClassNameString("Action");
			action_bt_Monster_AI_Chapter10_Tiaotiaowa_skill_tiaotiaowa_veryhard_node.SetId(3);
			sequence.AddChild(action_bt_Monster_AI_Chapter10_Tiaotiaowa_skill_tiaotiaowa_veryhard_node);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_Monster_AI_Chapter10_Tiaotiaowa_skill_tiaotiaowa_veryhard_node.HasEvents());
			bt.SetHasEvents(bt.HasEvents() | sequence.HasEvents());
			return true;
		}
	}
}
