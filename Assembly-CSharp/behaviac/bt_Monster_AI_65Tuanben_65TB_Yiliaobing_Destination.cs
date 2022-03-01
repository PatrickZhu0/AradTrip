using System;

namespace behaviac
{
	// Token: 0x02002D1C RID: 11548
	public static class bt_Monster_AI_65Tuanben_65TB_Yiliaobing_Destination
	{
		// Token: 0x06014325 RID: 82725 RVA: 0x00611338 File Offset: 0x0060F738
		public static bool build_behavior_tree(BehaviorTree bt)
		{
			bt.SetClassNameString("BehaviorTree");
			bt.SetId(-1);
			bt.SetName("Monster_AI/65Tuanben/65TB_Yiliaobing_Destination");
			bt.IsFSM = false;
			Selector selector = new Selector();
			selector.SetClassNameString("Selector");
			selector.SetId(0);
			bt.AddChild(selector);
			Sequence sequence = new Sequence();
			sequence.SetClassNameString("Sequence");
			sequence.SetId(1);
			selector.AddChild(sequence);
			Condition_bt_Monster_AI_65Tuanben_65TB_Yiliaobing_Destination_node3 condition_bt_Monster_AI_65Tuanben_65TB_Yiliaobing_Destination_node = new Condition_bt_Monster_AI_65Tuanben_65TB_Yiliaobing_Destination_node3();
			condition_bt_Monster_AI_65Tuanben_65TB_Yiliaobing_Destination_node.SetClassNameString("Condition");
			condition_bt_Monster_AI_65Tuanben_65TB_Yiliaobing_Destination_node.SetId(3);
			sequence.AddChild(condition_bt_Monster_AI_65Tuanben_65TB_Yiliaobing_Destination_node);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_Monster_AI_65Tuanben_65TB_Yiliaobing_Destination_node.HasEvents());
			Action_bt_Monster_AI_65Tuanben_65TB_Yiliaobing_Destination_node23 action_bt_Monster_AI_65Tuanben_65TB_Yiliaobing_Destination_node = new Action_bt_Monster_AI_65Tuanben_65TB_Yiliaobing_Destination_node23();
			action_bt_Monster_AI_65Tuanben_65TB_Yiliaobing_Destination_node.SetClassNameString("Action");
			action_bt_Monster_AI_65Tuanben_65TB_Yiliaobing_Destination_node.SetId(23);
			sequence.AddChild(action_bt_Monster_AI_65Tuanben_65TB_Yiliaobing_Destination_node);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_Monster_AI_65Tuanben_65TB_Yiliaobing_Destination_node.HasEvents());
			Action_bt_Monster_AI_65Tuanben_65TB_Yiliaobing_Destination_node4 action_bt_Monster_AI_65Tuanben_65TB_Yiliaobing_Destination_node2 = new Action_bt_Monster_AI_65Tuanben_65TB_Yiliaobing_Destination_node4();
			action_bt_Monster_AI_65Tuanben_65TB_Yiliaobing_Destination_node2.SetClassNameString("Action");
			action_bt_Monster_AI_65Tuanben_65TB_Yiliaobing_Destination_node2.SetId(4);
			sequence.AddChild(action_bt_Monster_AI_65Tuanben_65TB_Yiliaobing_Destination_node2);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_Monster_AI_65Tuanben_65TB_Yiliaobing_Destination_node2.HasEvents());
			selector.SetHasEvents(selector.HasEvents() | sequence.HasEvents());
			Sequence sequence2 = new Sequence();
			sequence2.SetClassNameString("Sequence");
			sequence2.SetId(2);
			selector.AddChild(sequence2);
			Condition_bt_Monster_AI_65Tuanben_65TB_Yiliaobing_Destination_node7 condition_bt_Monster_AI_65Tuanben_65TB_Yiliaobing_Destination_node2 = new Condition_bt_Monster_AI_65Tuanben_65TB_Yiliaobing_Destination_node7();
			condition_bt_Monster_AI_65Tuanben_65TB_Yiliaobing_Destination_node2.SetClassNameString("Condition");
			condition_bt_Monster_AI_65Tuanben_65TB_Yiliaobing_Destination_node2.SetId(7);
			sequence2.AddChild(condition_bt_Monster_AI_65Tuanben_65TB_Yiliaobing_Destination_node2);
			sequence2.SetHasEvents(sequence2.HasEvents() | condition_bt_Monster_AI_65Tuanben_65TB_Yiliaobing_Destination_node2.HasEvents());
			Action_bt_Monster_AI_65Tuanben_65TB_Yiliaobing_Destination_node5 action_bt_Monster_AI_65Tuanben_65TB_Yiliaobing_Destination_node3 = new Action_bt_Monster_AI_65Tuanben_65TB_Yiliaobing_Destination_node5();
			action_bt_Monster_AI_65Tuanben_65TB_Yiliaobing_Destination_node3.SetClassNameString("Action");
			action_bt_Monster_AI_65Tuanben_65TB_Yiliaobing_Destination_node3.SetId(5);
			sequence2.AddChild(action_bt_Monster_AI_65Tuanben_65TB_Yiliaobing_Destination_node3);
			sequence2.SetHasEvents(sequence2.HasEvents() | action_bt_Monster_AI_65Tuanben_65TB_Yiliaobing_Destination_node3.HasEvents());
			selector.SetHasEvents(selector.HasEvents() | sequence2.HasEvents());
			bt.SetHasEvents(bt.HasEvents() | selector.HasEvents());
			return true;
		}
	}
}
