<template>
  <Header></Header>

  <Modal />

  <template v-if="id">
    <div class="flex text-center pt-2 text-red-600 justify-center">
      Filtered by profile tags
    </div>
  </template>

  <div className="flex flex-col justify-center md:flex-row">
    <div class="p-2">
      <h1 class="pb-1 font-bold">Tags:</h1>
      <Tag :id="id"></Tag>
    </div>

    <div class="w-full">
      <FeedComponent :id="id"></FeedComponent>
    </div>

    <div
      class="flex flex-col border-solid w-max items-start p-4 text-xs md:text-lg cursor-pointer"
    >
      <div class="flex items-center w-max">
        <img
          src="/images/companies/nasa.png"
          class="rounded-full h-10 text-left"
          alt=""
        />
        <span class="opacity-80">NASA</span>
      </div>
      <div class="flex items-center w-max">
        <img
          src="/images/companies/nasa.png"
          class="rounded-full h-10 text-left"
          alt=""
        />
        <span class="opacity-80">Tech for Good Labs</span>
      </div>
    </div>
  </div>
</template>

<script>
import Header from "@/components/shared/Header.vue";
import FeedComponent from "@/components/FeedComponent.vue";
import Modal from "@/components/TagModal.vue";
import Tag from "@/components/Tags.vue";

export default {
  components: { Header, FeedComponent, Modal, Tag },
  data() {
    return {
      id: null,
    };
  },
  beforeCreate() {
    let tags = localStorage.getItem("tags");
    if (tags == null) {
      this.$router.push("/tags");
    }
  },
  created() {
    this.id = localStorage.getItem("id");
  },
  methods: {},
};
</script>
