<template>
  <div
    class="flex flex-col border-solid w-max items-start p-4 md:mr-2 text-xs md:text-lg cursor-pointer"
  >
    <template v-if="organizations.length > 0">
      <div
        class="flex items-center cursor-pointer hover:text-cyan-500"
        v-for="org in organizations"
        @click="toOrganization(org)"
      >
        <svg
          xmlns="http://www.w3.org/2000/svg"
          class="h-10 w-10 rounded-full text-left min-w-fit"
          viewBox="0 0 20 20"
          fill="currentColor"
        >
          <path
            fill-rule="evenodd"
            d="M10 9a3 3 0 100-6 3 3 0 000 6zm-7 9a7 7 0 1114 0H3z"
            clip-rule="evenodd"
          ></path>
        </svg>
        <span class="text-sm font-thin text-gray-900">{{ org.name }}</span>
      </div>
    </template>

    <template v-else> <Loading /> </template>
  </div>
</template>

<script>
import OrganizationService from "@/services/organization";
import Loading from "./shared/Loading.vue";

export default {
  components: { Loading },
  data() {
    return {
      organizations: [],
    };
  },
  methods: {
    toOrganization(org) {
      this.$router.push("/organization/" + org.id);
    },
  },
  created() {
    OrganizationService.list().then((response) => {
      this.organizations = response.data.organizations;
    });
  },
};
</script>
