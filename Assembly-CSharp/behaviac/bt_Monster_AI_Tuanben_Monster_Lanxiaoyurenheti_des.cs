using System;

namespace behaviac
{
	// Token: 0x02003B17 RID: 15127
	public static class bt_Monster_AI_Tuanben_Monster_Lanxiaoyurenheti_des
	{
		// Token: 0x06015DE7 RID: 89575 RVA: 0x0069B9EC File Offset: 0x00699DEC
		public static bool build_behavior_tree(BehaviorTree bt)
		{
			bt.SetClassNameString("BehaviorTree");
			bt.SetId(-1);
			bt.SetName("Monster_AI/Tuanben/Monster_Lanxiaoyurenheti_des");
			bt.IsFSM = false;
			Selector selector = new Selector();
			selector.SetClassNameString("Selector");
			selector.SetId(7);
			bt.AddChild(selector);
			Sequence sequence = new Sequence();
			sequence.SetClassNameString("Sequence");
			sequence.SetId(4);
			selector.AddChild(sequence);
			Condition_bt_Monster_AI_Tuanben_Monster_Lanxiaoyurenheti_des_node1 condition_bt_Monster_AI_Tuanben_Monster_Lanxiaoyurenheti_des_node = new Condition_bt_Monster_AI_Tuanben_Monster_Lanxiaoyurenheti_des_node1();
			condition_bt_Monster_AI_Tuanben_Monster_Lanxiaoyurenheti_des_node.SetClassNameString("Condition");
			condition_bt_Monster_AI_Tuanben_Monster_Lanxiaoyurenheti_des_node.SetId(1);
			sequence.AddChild(condition_bt_Monster_AI_Tuanben_Monster_Lanxiaoyurenheti_des_node);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_Monster_AI_Tuanben_Monster_Lanxiaoyurenheti_des_node.HasEvents());
			Condition_bt_Monster_AI_Tuanben_Monster_Lanxiaoyurenheti_des_node8 condition_bt_Monster_AI_Tuanben_Monster_Lanxiaoyurenheti_des_node2 = new Condition_bt_Monster_AI_Tuanben_Monster_Lanxiaoyurenheti_des_node8();
			condition_bt_Monster_AI_Tuanben_Monster_Lanxiaoyurenheti_des_node2.SetClassNameString("Condition");
			condition_bt_Monster_AI_Tuanben_Monster_Lanxiaoyurenheti_des_node2.SetId(8);
			sequence.AddChild(condition_bt_Monster_AI_Tuanben_Monster_Lanxiaoyurenheti_des_node2);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_Monster_AI_Tuanben_Monster_Lanxiaoyurenheti_des_node2.HasEvents());
			Condition_bt_Monster_AI_Tuanben_Monster_Lanxiaoyurenheti_des_node0 condition_bt_Monster_AI_Tuanben_Monster_Lanxiaoyurenheti_des_node3 = new Condition_bt_Monster_AI_Tuanben_Monster_Lanxiaoyurenheti_des_node0();
			condition_bt_Monster_AI_Tuanben_Monster_Lanxiaoyurenheti_des_node3.SetClassNameString("Condition");
			condition_bt_Monster_AI_Tuanben_Monster_Lanxiaoyurenheti_des_node3.SetId(0);
			sequence.AddChild(condition_bt_Monster_AI_Tuanben_Monster_Lanxiaoyurenheti_des_node3);
			sequence.SetHasEvents(sequence.HasEvents() | condition_bt_Monster_AI_Tuanben_Monster_Lanxiaoyurenheti_des_node3.HasEvents());
			Action_bt_Monster_AI_Tuanben_Monster_Lanxiaoyurenheti_des_node3 action_bt_Monster_AI_Tuanben_Monster_Lanxiaoyurenheti_des_node = new Action_bt_Monster_AI_Tuanben_Monster_Lanxiaoyurenheti_des_node3();
			action_bt_Monster_AI_Tuanben_Monster_Lanxiaoyurenheti_des_node.SetClassNameString("Action");
			action_bt_Monster_AI_Tuanben_Monster_Lanxiaoyurenheti_des_node.SetId(3);
			sequence.AddChild(action_bt_Monster_AI_Tuanben_Monster_Lanxiaoyurenheti_des_node);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_Monster_AI_Tuanben_Monster_Lanxiaoyurenheti_des_node.HasEvents());
			Action_bt_Monster_AI_Tuanben_Monster_Lanxiaoyurenheti_des_node2 action_bt_Monster_AI_Tuanben_Monster_Lanxiaoyurenheti_des_node2 = new Action_bt_Monster_AI_Tuanben_Monster_Lanxiaoyurenheti_des_node2();
			action_bt_Monster_AI_Tuanben_Monster_Lanxiaoyurenheti_des_node2.SetClassNameString("Action");
			action_bt_Monster_AI_Tuanben_Monster_Lanxiaoyurenheti_des_node2.SetId(2);
			sequence.AddChild(action_bt_Monster_AI_Tuanben_Monster_Lanxiaoyurenheti_des_node2);
			sequence.SetHasEvents(sequence.HasEvents() | action_bt_Monster_AI_Tuanben_Monster_Lanxiaoyurenheti_des_node2.HasEvents());
			selector.SetHasEvents(selector.HasEvents() | sequence.HasEvents());
			Sequence sequence2 = new Sequence();
			sequence2.SetClassNameString("Sequence");
			sequence2.SetId(5);
			selector.AddChild(sequence2);
			Action_bt_Monster_AI_Tuanben_Monster_Lanxiaoyurenheti_des_node6 action_bt_Monster_AI_Tuanben_Monster_Lanxiaoyurenheti_des_node3 = new Action_bt_Monster_AI_Tuanben_Monster_Lanxiaoyurenheti_des_node6();
			action_bt_Monster_AI_Tuanben_Monster_Lanxiaoyurenheti_des_node3.SetClassNameString("Action");
			action_bt_Monster_AI_Tuanben_Monster_Lanxiaoyurenheti_des_node3.SetId(6);
			sequence2.AddChild(action_bt_Monster_AI_Tuanben_Monster_Lanxiaoyurenheti_des_node3);
			sequence2.SetHasEvents(sequence2.HasEvents() | action_bt_Monster_AI_Tuanben_Monster_Lanxiaoyurenheti_des_node3.HasEvents());
			selector.SetHasEvents(selector.HasEvents() | sequence2.HasEvents());
			bt.SetHasEvents(bt.HasEvents() | selector.HasEvents());
			return true;
		}
	}
}
