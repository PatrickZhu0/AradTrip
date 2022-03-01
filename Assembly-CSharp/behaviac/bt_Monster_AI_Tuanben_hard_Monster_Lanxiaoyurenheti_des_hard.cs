using System;

namespace behaviac
{
	// Token: 0x02003D36 RID: 15670
	public static class bt_Monster_AI_Tuanben_hard_Monster_Lanxiaoyurenheti_des_hard
	{
		// Token: 0x06016205 RID: 90629 RVA: 0x006B050C File Offset: 0x006AE90C
		public static bool build_behavior_tree(BehaviorTree bt)
		{
			bt.SetClassNameString("BehaviorTree");
			bt.SetId(-1);
			bt.SetName("Monster_AI/Tuanben_hard/Monster_Lanxiaoyurenheti_des_hard");
			bt.IsFSM = false;
			Selector selector = new Selector();
			selector.SetClassNameString("Selector");
			selector.SetId(7);
			bt.AddChild(selector);
			Sequence sequence = new Sequence();
			sequence.SetClassNameString("Sequence");
			sequence.SetId(4);
			selector.AddChild(sequence);
			Condition_bt_Monster_AI_Tuanben_hard_Monster_Lanxiaoyurenheti_des_hard_node1 condition_bt_Monster_AI_Tuanben_hard_Monster_Lanxiaoyurenheti_des_hard_node = new Condition_bt_Monster_AI_Tuanben_hard_Monster_Lanxiaoyurenheti_des_hard_node1();
			condition_bt_Monster_AI_Tuanben_hard_Monster_Lanxiaoyurenheti_des_hard_node.SetClassNameString("Condition");
			condition_bt_Monster_AI_Tuanben_hard_Monster_Lanxiaoyurenheti_des_hard_node.SetId(1);
			sequence.AddChild(condition_bt_Monster_AI_Tuanben_hard_Monster_Lanxiaoyurenheti_des_hard_node);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_Monster_AI_Tuanben_hard_Monster_Lanxiaoyurenheti_des_hard_node.HasEvents());
			Condition_bt_Monster_AI_Tuanben_hard_Monster_Lanxiaoyurenheti_des_hard_node8 condition_bt_Monster_AI_Tuanben_hard_Monster_Lanxiaoyurenheti_des_hard_node2 = new Condition_bt_Monster_AI_Tuanben_hard_Monster_Lanxiaoyurenheti_des_hard_node8();
			condition_bt_Monster_AI_Tuanben_hard_Monster_Lanxiaoyurenheti_des_hard_node2.SetClassNameString("Condition");
			condition_bt_Monster_AI_Tuanben_hard_Monster_Lanxiaoyurenheti_des_hard_node2.SetId(8);
			sequence.AddChild(condition_bt_Monster_AI_Tuanben_hard_Monster_Lanxiaoyurenheti_des_hard_node2);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_Monster_AI_Tuanben_hard_Monster_Lanxiaoyurenheti_des_hard_node2.HasEvents());
			Condition_bt_Monster_AI_Tuanben_hard_Monster_Lanxiaoyurenheti_des_hard_node0 condition_bt_Monster_AI_Tuanben_hard_Monster_Lanxiaoyurenheti_des_hard_node3 = new Condition_bt_Monster_AI_Tuanben_hard_Monster_Lanxiaoyurenheti_des_hard_node0();
			condition_bt_Monster_AI_Tuanben_hard_Monster_Lanxiaoyurenheti_des_hard_node3.SetClassNameString("Condition");
			condition_bt_Monster_AI_Tuanben_hard_Monster_Lanxiaoyurenheti_des_hard_node3.SetId(0);
			sequence.AddChild(condition_bt_Monster_AI_Tuanben_hard_Monster_Lanxiaoyurenheti_des_hard_node3);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_Monster_AI_Tuanben_hard_Monster_Lanxiaoyurenheti_des_hard_node3.HasEvents());
			Action_bt_Monster_AI_Tuanben_hard_Monster_Lanxiaoyurenheti_des_hard_node3 action_bt_Monster_AI_Tuanben_hard_Monster_Lanxiaoyurenheti_des_hard_node = new Action_bt_Monster_AI_Tuanben_hard_Monster_Lanxiaoyurenheti_des_hard_node3();
			action_bt_Monster_AI_Tuanben_hard_Monster_Lanxiaoyurenheti_des_hard_node.SetClassNameString("Action");
			action_bt_Monster_AI_Tuanben_hard_Monster_Lanxiaoyurenheti_des_hard_node.SetId(3);
			sequence.AddChild(action_bt_Monster_AI_Tuanben_hard_Monster_Lanxiaoyurenheti_des_hard_node);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_Monster_AI_Tuanben_hard_Monster_Lanxiaoyurenheti_des_hard_node.HasEvents());
			Action_bt_Monster_AI_Tuanben_hard_Monster_Lanxiaoyurenheti_des_hard_node2 action_bt_Monster_AI_Tuanben_hard_Monster_Lanxiaoyurenheti_des_hard_node2 = new Action_bt_Monster_AI_Tuanben_hard_Monster_Lanxiaoyurenheti_des_hard_node2();
			action_bt_Monster_AI_Tuanben_hard_Monster_Lanxiaoyurenheti_des_hard_node2.SetClassNameString("Action");
			action_bt_Monster_AI_Tuanben_hard_Monster_Lanxiaoyurenheti_des_hard_node2.SetId(2);
			sequence.AddChild(action_bt_Monster_AI_Tuanben_hard_Monster_Lanxiaoyurenheti_des_hard_node2);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_Monster_AI_Tuanben_hard_Monster_Lanxiaoyurenheti_des_hard_node2.HasEvents());
			selector.SetHasEvents(selector.HasEvents() | sequence.HasEvents());
			Sequence sequence2 = new Sequence();
			sequence2.SetClassNameString("Sequence");
			sequence2.SetId(5);
			selector.AddChild(sequence2);
			Action_bt_Monster_AI_Tuanben_hard_Monster_Lanxiaoyurenheti_des_hard_node6 action_bt_Monster_AI_Tuanben_hard_Monster_Lanxiaoyurenheti_des_hard_node3 = new Action_bt_Monster_AI_Tuanben_hard_Monster_Lanxiaoyurenheti_des_hard_node6();
			action_bt_Monster_AI_Tuanben_hard_Monster_Lanxiaoyurenheti_des_hard_node3.SetClassNameString("Action");
			action_bt_Monster_AI_Tuanben_hard_Monster_Lanxiaoyurenheti_des_hard_node3.SetId(6);
			sequence2.AddChild(action_bt_Monster_AI_Tuanben_hard_Monster_Lanxiaoyurenheti_des_hard_node3);
			sequence2.SetHasEvents(sequence2.HasEvents() | action_bt_Monster_AI_Tuanben_hard_Monster_Lanxiaoyurenheti_des_hard_node3.HasEvents());
			selector.SetHasEvents(selector.HasEvents() | sequence2.HasEvents());
			bt.SetHasEvents(bt.HasEvents() | selector.HasEvents());
			return true;
		}
	}
}
