<template>
  <Header></Header>

  <Modal />

  <template v-if="id">
    <div class="flex text-center pt-2 text-red-600 justify-center">
      Filtered by profile tags
    </div>
  </template>

  <div className="flex justify-center">
    <div class="flex border-solid border-2 border-indigo-600 w-max">
      <img
        src="/images/nasachallenge.jpeg"
        class="rounded-full h-20 text-left"
        alt=""
      />
      <span></span>
    </div>

    <div class="w-full">
      <FeedComponent :id="id"></FeedComponent>
    </div>

    <div class="p-5">
      <Tag :id="id"></Tag>
    </div>
  </div>
</template>

<script>
import Header from "@/components/shared/Header.vue";
import FeedComponent from "@/components/FeedComponent.vue";
import Modal from "@/components/Modal.vue";
import Tag from "@/components/Tags.vue";

export default {
  components: { Header, FeedComponent, Modal, Tag },
  data() {
    return {
      id: null,
    };
  },
  created() {
    this.id = localStorage.getItem("id");
  },
  methods: {},
};
</script>
