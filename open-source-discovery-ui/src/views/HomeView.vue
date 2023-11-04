<template>
  <Header></Header>

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
    <OrganizationsContainer />
  </div>
</template>

<script>
import Header from "@/components/shared/Header.vue";
import FeedComponent from "@/components/FeedComponent.vue";
import OrganizationsContainer from "@/components/OrganizationsContainer.vue";
import Tag from "@/components/Tags.vue";

export default {
  components: { Header, FeedComponent, Tag, OrganizationsContainer },
  data() {
    return {
      id: null,
    };
  },
  beforeCreate() {
    let tags = localStorage.getItem("local-tags");
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
