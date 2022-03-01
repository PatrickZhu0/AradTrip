using System;

namespace behaviac
{
	// Token: 0x02002B9E RID: 11166
	public static class bt_Monster_AI_65Tuanben_65TB_HundunYashou_Event
	{
		// Token: 0x06014046 RID: 81990 RVA: 0x00602EEC File Offset: 0x006012EC
		public static bool build_behavior_tree(BehaviorTree bt)
		{
			bt.SetClassNameString("BehaviorTree");
			bt.SetId(-1);
			bt.SetName("Monster_AI/65Tuanben/65TB_HundunYashou_Event");
			bt.IsFSM = false;
			Parallel_bt_Monster_AI_65Tuanben_65TB_HundunYashou_Event_node1 parallel_bt_Monster_AI_65Tuanben_65TB_HundunYashou_Event_node = new Parallel_bt_Monster_AI_65Tuanben_65TB_HundunYashou_Event_node1();
			parallel_bt_Monster_AI_65Tuanben_65TB_HundunYashou_Event_node.SetClassNameString("Parallel");
			parallel_bt_Monster_AI_65Tuanben_65TB_HundunYashou_Event_node.SetId(1);
			bt.AddChild(parallel_bt_Monster_AI_65Tuanben_65TB_HundunYashou_Event_node);
			Sequence sequence = new Sequence();
			sequence.SetClassNameString("Sequence");
			sequence.SetId(5);
			parallel_bt_Monster_AI_65Tuanben_65TB_HundunYashou_Event_node.AddChild(sequence);
			Condition_bt_Monster_AI_65Tuanben_65TB_HundunYashou_Event_node6 condition_bt_Monster_AI_65Tuanben_65TB_HundunYashou_Event_node = new Condition_bt_Monster_AI_65Tuanben_65TB_HundunYashou_Event_node6();
			condition_bt_Monster_AI_65Tuanben_65TB_HundunYashou_Event_node.SetClassNameString("Condition");
			condition_bt_Monster_AI_65Tuanben_65TB_HundunYashou_Event_node.SetId(6);
			sequence.AddChild(condition_bt_Monster_AI_65Tuanben_65TB_HundunYashou_Event_node);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_Monster_AI_65Tuanben_65TB_HundunYashou_Event_node.HasEvents());
			Action_bt_Monster_AI_65Tuanben_65TB_HundunYashou_Event_node8 action_bt_Monster_AI_65Tuanben_65TB_HundunYashou_Event_node = new Action_bt_Monster_AI_65Tuanben_65TB_HundunYashou_Event_node8();
			action_bt_Monster_AI_65Tuanben_65TB_HundunYashou_Event_node.SetClassNameString("Action");
			action_bt_Monster_AI_65Tuanben_65TB_HundunYashou_Event_node.SetId(8);
			sequence.AddChild(action_bt_Monster_AI_65Tuanben_65TB_HundunYashou_Event_node);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_Monster_AI_65Tuanben_65TB_HundunYashou_Event_node.HasEvents());
			parallel_bt_Monster_AI_65Tuanben_65TB_HundunYashou_Event_node.SetHasEvents(parallel_bt_Monster_AI_65Tuanben_65TB_HundunYashou_Event_node.HasEvents() | sequence.HasEvents());
			Sequence sequence2 = new Sequence();
			sequence2.SetClassNameString("Sequence");
			sequence2.SetId(0);
			parallel_bt_Monster_AI_65Tuanben_65TB_HundunYashou_Event_node.AddChild(sequence2);
			Condition_bt_Monster_AI_65Tuanben_65TB_HundunYashou_Event_node3 condition_bt_Monster_AI_65Tuanben_65TB_HundunYashou_Event_node2 = new Condition_bt_Monster_AI_65Tuanben_65TB_HundunYashou_Event_node3();
			condition_bt_Monster_AI_65Tuanben_65TB_HundunYashou_Event_node2.SetClassNameString("Condition");
			condition_bt_Monster_AI_65Tuanben_65TB_HundunYashou_Event_node2.SetId(3);
			sequence2.AddChild(condition_bt_Monster_AI_65Tuanben_65TB_HundunYashou_Event_node2);
			sequence2.SetHasEvents(sequence2.HasEvents() | condition_bt_Monster_AI_65Tuanben_65TB_HundunYashou_Event_node2.HasEvents());
			Condition_bt_Monster_AI_65Tuanben_65TB_HundunYashou_Event_node4 condition_bt_Monster_AI_65Tuanben_65TB_HundunYashou_Event_node3 = new Condition_bt_Monster_AI_65Tuanben_65TB_HundunYashou_Event_node4();
			condition_bt_Monster_AI_65Tuanben_65TB_HundunYashou_Event_node3.SetClassNameString("Condition");
			condition_bt_Monster_AI_65Tuanben_65TB_HundunYashou_Event_node3.SetId(4);
			sequence2.AddChild(condition_bt_Monster_AI_65Tuanben_65TB_HundunYashou_Event_node3);
			sequence2.SetHasEvents(sequence2.HasEvents() | condition_bt_Monster_AI_65Tuanben_65TB_HundunYashou_Event_node3.HasEvents());
			Action_bt_Monster_AI_65Tuanben_65TB_HundunYashou_Event_node2 action_bt_Monster_AI_65Tuanben_65TB_HundunYashou_Event_node2 = new Action_bt_Monster_AI_65Tuanben_65TB_HundunYashou_Event_node2();
			action_bt_Monster_AI_65Tuanben_65TB_HundunYashou_Event_node2.SetClassNameString("Action");
			action_bt_Monster_AI_65Tuanben_65TB_HundunYashou_Event_node2.SetId(2);
			sequence2.AddChild(action_bt_Monster_AI_65Tuanben_65TB_HundunYashou_Event_node2);
			sequence2.SetHasEvents(sequence2.HasEvents() | action_bt_Monster_AI_65Tuanben_65TB_HundunYashou_Event_node2.HasEvents());
			parallel_bt_Monster_AI_65Tuanben_65TB_HundunYashou_Event_node.SetHasEvents(parallel_bt_Monster_AI_65Tuanben_65TB_HundunYashou_Event_node.HasEvents() | sequence2.HasEvents());
			bt.SetHasEvents(bt.HasEvents() | parallel_bt_Monster_AI_65Tuanben_65TB_HundunYashou_Event_node.HasEvents());
			return true;
		}
	}
}
