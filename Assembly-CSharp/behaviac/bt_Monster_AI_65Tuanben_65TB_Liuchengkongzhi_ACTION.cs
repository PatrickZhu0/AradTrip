using System;

namespace behaviac
{
	// Token: 0x02002BC3 RID: 11203
	public static class bt_Monster_AI_65Tuanben_65TB_Liuchengkongzhi_ACTION
	{
		// Token: 0x0601408A RID: 82058 RVA: 0x00604494 File Offset: 0x00602894
		public static bool build_behavior_tree(BehaviorTree bt)
		{
			bt.SetClassNameString("BehaviorTree");
			bt.SetId(-1);
			bt.SetName("Monster_AI/65Tuanben/65TB_Liuchengkongzhi_ACTION");
			bt.IsFSM = false;
			Parallel_bt_Monster_AI_65Tuanben_65TB_Liuchengkongzhi_ACTION_node16 parallel_bt_Monster_AI_65Tuanben_65TB_Liuchengkongzhi_ACTION_node = new Parallel_bt_Monster_AI_65Tuanben_65TB_Liuchengkongzhi_ACTION_node16();
			parallel_bt_Monster_AI_65Tuanben_65TB_Liuchengkongzhi_ACTION_node.SetClassNameString("Parallel");
			parallel_bt_Monster_AI_65Tuanben_65TB_Liuchengkongzhi_ACTION_node.SetId(16);
			bt.AddChild(parallel_bt_Monster_AI_65Tuanben_65TB_Liuchengkongzhi_ACTION_node);
			Sequence sequence = new Sequence();
			sequence.SetClassNameString("Sequence");
			sequence.SetId(25);
			parallel_bt_Monster_AI_65Tuanben_65TB_Liuchengkongzhi_ACTION_node.AddChild(sequence);
			Condition_bt_Monster_AI_65Tuanben_65TB_Liuchengkongzhi_ACTION_node2 condition_bt_Monster_AI_65Tuanben_65TB_Liuchengkongzhi_ACTION_node = new Condition_bt_Monster_AI_65Tuanben_65TB_Liuchengkongzhi_ACTION_node2();
			condition_bt_Monster_AI_65Tuanben_65TB_Liuchengkongzhi_ACTION_node.SetClassNameString("Condition");
			condition_bt_Monster_AI_65Tuanben_65TB_Liuchengkongzhi_ACTION_node.SetId(2);
			sequence.AddChild(condition_bt_Monster_AI_65Tuanben_65TB_Liuchengkongzhi_ACTION_node);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_Monster_AI_65Tuanben_65TB_Liuchengkongzhi_ACTION_node.HasEvents());
			Condition_bt_Monster_AI_65Tuanben_65TB_Liuchengkongzhi_ACTION_node36 condition_bt_Monster_AI_65Tuanben_65TB_Liuchengkongzhi_ACTION_node2 = new Condition_bt_Monster_AI_65Tuanben_65TB_Liuchengkongzhi_ACTION_node36();
			condition_bt_Monster_AI_65Tuanben_65TB_Liuchengkongzhi_ACTION_node2.SetClassNameString("Condition");
			condition_bt_Monster_AI_65Tuanben_65TB_Liuchengkongzhi_ACTION_node2.SetId(36);
			sequence.AddChild(condition_bt_Monster_AI_65Tuanben_65TB_Liuchengkongzhi_ACTION_node2);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_Monster_AI_65Tuanben_65TB_Liuchengkongzhi_ACTION_node2.HasEvents());
			Condition_bt_Monster_AI_65Tuanben_65TB_Liuchengkongzhi_ACTION_node1 condition_bt_Monster_AI_65Tuanben_65TB_Liuchengkongzhi_ACTION_node3 = new Condition_bt_Monster_AI_65Tuanben_65TB_Liuchengkongzhi_ACTION_node1();
			condition_bt_Monster_AI_65Tuanben_65TB_Liuchengkongzhi_ACTION_node3.SetClassNameString("Condition");
			condition_bt_Monster_AI_65Tuanben_65TB_Liuchengkongzhi_ACTION_node3.SetId(1);
			sequence.AddChild(condition_bt_Monster_AI_65Tuanben_65TB_Liuchengkongzhi_ACTION_node3);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_Monster_AI_65Tuanben_65TB_Liuchengkongzhi_ACTION_node3.HasEvents());
			Assignment_bt_Monster_AI_65Tuanben_65TB_Liuchengkongzhi_ACTION_node3 assignment_bt_Monster_AI_65Tuanben_65TB_Liuchengkongzhi_ACTION_node = new Assignment_bt_Monster_AI_65Tuanben_65TB_Liuchengkongzhi_ACTION_node3();
			assignment_bt_Monster_AI_65Tuanben_65TB_Liuchengkongzhi_ACTION_node.SetClassNameString("Assignment");
			assignment_bt_Monster_AI_65Tuanben_65TB_Liuchengkongzhi_ACTION_node.SetId(3);
			sequence.AddChild(assignment_bt_Monster_AI_65Tuanben_65TB_Liuchengkongzhi_ACTION_node);
			sequence.SetHasEvents(sequence.HasEvents() | assignment_bt_Monster_AI_65Tuanben_65TB_Liuchengkongzhi_ACTION_node.HasEvents());
			parallel_bt_Monster_AI_65Tuanben_65TB_Liuchengkongzhi_ACTION_node.SetHasEvents(parallel_bt_Monster_AI_65Tuanben_65TB_Liuchengkongzhi_ACTION_node.HasEvents() | sequence.HasEvents());
			Sequence sequence2 = new Sequence();
			sequence2.SetClassNameString("Sequence");
			sequence2.SetId(0);
			parallel_bt_Monster_AI_65Tuanben_65TB_Liuchengkongzhi_ACTION_node.AddChild(sequence2);
			Condition_bt_Monster_AI_65Tuanben_65TB_Liuchengkongzhi_ACTION_node4 condition_bt_Monster_AI_65Tuanben_65TB_Liuchengkongzhi_ACTION_node4 = new Condition_bt_Monster_AI_65Tuanben_65TB_Liuchengkongzhi_ACTION_node4();
			condition_bt_Monster_AI_65Tuanben_65TB_Liuchengkongzhi_ACTION_node4.SetClassNameString("Condition");
			condition_bt_Monster_AI_65Tuanben_65TB_Liuchengkongzhi_ACTION_node4.SetId(4);
			sequence2.AddChild(condition_bt_Monster_AI_65Tuanben_65TB_Liuchengkongzhi_ACTION_node4);
			sequence2.SetHasEvents(sequence2.HasEvents() | condition_bt_Monster_AI_65Tuanben_65TB_Liuchengkongzhi_ACTION_node4.HasEvents());
			Condition_bt_Monster_AI_65Tuanben_65TB_Liuchengkongzhi_ACTION_node5 condition_bt_Monster_AI_65Tuanben_65TB_Liuchengkongzhi_ACTION_node5 = new Condition_bt_Monster_AI_65Tuanben_65TB_Liuchengkongzhi_ACTION_node5();
			condition_bt_Monster_AI_65Tuanben_65TB_Liuchengkongzhi_ACTION_node5.SetClassNameString("Condition");
			condition_bt_Monster_AI_65Tuanben_65TB_Liuchengkongzhi_ACTION_node5.SetId(5);
			sequence2.AddChild(condition_bt_Monster_AI_65Tuanben_65TB_Liuchengkongzhi_ACTION_node5);
			sequence2.SetHasEvents(sequence2.HasEvents() | condition_bt_Monster_AI_65Tuanben_65TB_Liuchengkongzhi_ACTION_node5.HasEvents());
			Condition_bt_Monster_AI_65Tuanben_65TB_Liuchengkongzhi_ACTION_node8 condition_bt_Monster_AI_65Tuanben_65TB_Liuchengkongzhi_ACTION_node6 = new Condition_bt_Monster_AI_65Tuanben_65TB_Liuchengkongzhi_ACTION_node8();
			condition_bt_Monster_AI_65Tuanben_65TB_Liuchengkongzhi_ACTION_node6.SetClassNameString("Condition");
			condition_bt_Monster_AI_65Tuanben_65TB_Liuchengkongzhi_ACTION_node6.SetId(8);
			sequence2.AddChild(condition_bt_Monster_AI_65Tuanben_65TB_Liuchengkongzhi_ACTION_node6);
			sequence2.SetHasEvents(sequence2.HasEvents() | condition_bt_Monster_AI_65Tuanben_65TB_Liuchengkongzhi_ACTION_node6.HasEvents());
			Condition_bt_Monster_AI_65Tuanben_65TB_Liuchengkongzhi_ACTION_node7 condition_bt_Monster_AI_65Tuanben_65TB_Liuchengkongzhi_ACTION_node7 = new Condition_bt_Monster_AI_65Tuanben_65TB_Liuchengkongzhi_ACTION_node7();
			condition_bt_Monster_AI_65Tuanben_65TB_Liuchengkongzhi_ACTION_node7.SetClassNameString("Condition");
			condition_bt_Monster_AI_65Tuanben_65TB_Liuchengkongzhi_ACTION_node7.SetId(7);
			sequence2.AddChild(condition_bt_Monster_AI_65Tuanben_65TB_Liuchengkongzhi_ACTION_node7);
			sequence2.SetHasEvents(sequence2.HasEvents() | condition_bt_Monster_AI_65Tuanben_65TB_Liuchengkongzhi_ACTION_node7.HasEvents());
			Action_bt_Monster_AI_65Tuanben_65TB_Liuchengkongzhi_ACTION_node6 action_bt_Monster_AI_65Tuanben_65TB_Liuchengkongzhi_ACTION_node = new Action_bt_Monster_AI_65Tuanben_65TB_Liuchengkongzhi_ACTION_node6();
			action_bt_Monster_AI_65Tuanben_65TB_Liuchengkongzhi_ACTION_node.SetClassNameString("Action");
			action_bt_Monster_AI_65Tuanben_65TB_Liuchengkongzhi_ACTION_node.SetId(6);
			sequence2.AddChild(action_bt_Monster_AI_65Tuanben_65TB_Liuchengkongzhi_ACTION_node);
			sequence2.SetHasEvents(sequence2.HasEvents() | action_bt_Monster_AI_65Tuanben_65TB_Liuchengkongzhi_ACTION_node.HasEvents());
			parallel_bt_Monster_AI_65Tuanben_65TB_Liuchengkongzhi_ACTION_node.SetHasEvents(parallel_bt_Monster_AI_65Tuanben_65TB_Liuchengkongzhi_ACTION_node.HasEvents() | sequence2.HasEvents());
			bt.SetHasEvents(bt.HasEvents() | parallel_bt_Monster_AI_65Tuanben_65TB_Liuchengkongzhi_ACTION_node.HasEvents());
			return true;
		}
	}
}
