<template>
  <Header></Header>

  <div class="container mx-auto px-4 mt-8">
    <a href="/" class="mb-1 font-medium">&larr; Back</a>
    <div
      class="flex flex-col min-w-0 break-words bg-white w-full mb-6 shadow-xl rounded-lg"
    >
      <div class="">
        <div class="text-center mt-12">
          <h3
            class="text-4xl font-semibold leading-normal mb-2 text-blueGray-700 mb-2"
          >
            <a>{{ project.title }}</a>
          </h3>

          <a
            class="font-bold uppercase tracking-widest text-xs md:text-lg text-blue-500 hover:underline hover:cursor-pointer"
            :href="project.link"
            target="_blank"
            >Project Link</a
          >

          <!-- <div
            class="text-sm leading-normal mt-0 mb-2 text-blueGray-400 font-bold uppercase"
          >
            <i class="fas fa-map-marker-alt mr-2 text-lg text-blueGray-400"></i>
            LOCAL (A preencher)
          </div> -->

          <div class="mb-2 text-blueGray-600 mt-10">
            <a
              v-on:click="toOrganization()"
              class="fas fa-briefcase mr-2 text-lg text-blue-600 dark:text-blue-500 hover:underline hover:cursor-pointer"
              >{{ organization.name }}</a
            >
          </div>
          <div class="flex flex-row justify-center">
            <span
              v-for="tag in project.tag_ids"
              class="flex flex-wrap pl-4 pr-4 py-2 m-1 justify-between items-center text-sm font-medium rounded-xl cursor-pointer bg-purple-500 text-gray-200 hover:bg-purple-600 hover:text-gray-100 dark:bg-gray-700 dark:text-gray-200 dark:hover:bg-gray-800 dark:hover:text-gray-100"
            >
              {{ tag }}
            </span>
          </div>
        </div>
        <div class="mt-10 py-10 border-t border-blueGray-200 text-center">
          <div class="flex flex-wrap justify-center">
            <div class="w-full lg:w-9/12 px-4">
              <p
                class="mb-4 text-lg leading-relaxed text-blueGray-700"
                v-html="project.description"
              ></p>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import Header from "@/components/shared/Header.vue";
import ProjectService from "@/services/project";
import OrganizationService from "@/services/organization";

export default {
  components: { Header },
  props: { id: String },
  data() {
    return {
      project: {},
      organization: {},
      tags: [],
    };
  },
  methods: {
    toOrganization() {
      this.$router.push("/organization/" + this.project.organization_id);
    },
  },
  created() {
    ProjectService.getById(this.id)
      .then((response) => {
        this.project = response.data;
      })
      .finally((r) => {
        OrganizationService.getById(this.project.organization_id).then(
          (response) => {
            this.organization = response.data;
          }
        );
      });

    ProjectService.getTagsByProjectId(this.id).then((response) => {
      this.tags = response.data;
    });
  },
};
</script>
