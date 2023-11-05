<template>
  <div className="flex flex-col p-4">
    <div v-for="project in projects">
      <div
        class="max-w-sm lg:max-w-full hover:cursor-pointer mb-2"
        v-on:click="viewProject(project.id)"
      >
        <div
          class="hover:border-cyan-400 border-r border-b border-l border-t border-gray-400 lg:border-t lg:border-gray-400 bg-white rounded-b lg:rounded-b-none lg:rounded-r p-4 flex flex-col justify-between leading-normal"
        >
          <div class="mb-8">
            <div class="flex">
              <img src="/images/companies/nasa.png" class="h-8 w-10" alt="" />
              <div class="text-gray-900 font-bold text-xl mb-2">
                {{ project.name }}
              </div>
            </div>

            <p class="text-gray-700 text-base" v-html="project.description"></p>
          </div>
          <div class="flex flex-row justify-start">
            <span
              v-for="tag in project.tagDescriptions"
              class="flex flex-wrap pl-4 pr-4 py-2 m-1 justify-between items-center text-sm font-medium rounded-xl cursor-pointer bg-purple-500 text-gray-200 hover:bg-purple-600 hover:text-gray-100 dark:bg-gray-700 dark:text-gray-200 dark:hover:bg-gray-800 dark:hover:text-gray-100"
            >
              {{ tag }}
            </span>
          </div>
          <div class="flex items-center">
            <div class="text-sm">
              <p class="text-gray-900 leading-none"></p>
              <p class="text-gray-600"></p>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import ProjectCard from "./shared/ProjectCard.vue";
import ServiceProject from "@/services/project.js";
import TagService from "@/services/tag";

export default {
  props: { id: String },
  components: { ProjectCard },
  data() {
    return {
      projects: [],
      description_formatted: "",
      title_formatted: "",
    };
  },
  methods: {
    viewProject(id) {
      this.$router.push("/project/" + id);
    },
  },
  created() {
    if (this.id != null) {
      TagService.getTagsByUserId(this.id).then((response) => {
        let tagIds = [];
        response.data.tags.forEach((t) => {
          tagIds.push(t.id);
        });
        ServiceProject.getListFiltered(tagIds).then((response) => {
          this.projects = response.data.projects;
        });
      });
    } else {
      let tags_ids = [];
      let local_tags_string = localStorage.getItem("local-tags");
      if (local_tags_string != null) {
        let tags = JSON.parse(local_tags_string);
        tags_ids = tags.map((t) => t.id);
      }
      ServiceProject.getListFiltered(tags_ids).then((response) => {
        this.projects = response.data.projects;
      });
    }
  },
};
</script>
